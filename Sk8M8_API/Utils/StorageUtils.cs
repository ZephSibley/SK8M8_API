using Azure.Storage.Blobs;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.FFMPEG;
using FFMpegCore.FFMPEG.Enums;
using Microsoft.AspNetCore.Http;
using nClam;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API
{
    public static class StorageUtils
    {
        /// <summary>
        /// On-demand virus scanner for temp files.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>bool</returns>
        public static async Task<bool> FileIsSafe(this FileInfo file)
        {
            var clam = new ClamClient("localhost", 3310);
            var scanResult = await clam.ScanFileOnServerAsync(file.FullName);

            switch (scanResult.Result)
            {
                case ClamScanResults.Clean:
                    return true;
                case ClamScanResults.VirusDetected:
                    Console.WriteLine("Virus Found!");
                    Console.WriteLine("Virus name: {0}", scanResult.InfectedFiles.First().VirusName);
                    return false;
                case ClamScanResults.Error:
                    Console.WriteLine("Woah an error occured! Error: {0}", scanResult.RawResult);
                    return false;
                default:
                    Console.WriteLine("VIRUS SCAN DEFAULTING");
                    return false;
            }
        }
        /// <summary>
        /// Transcodes video files to mp4
        /// </summary>
        /// <param name="file">Video File</param>
        /// <returns>The transcoded file</returns>
        public static FileInfo Transcode(this FileInfo file)
        {
            using (var encoder = new FFMpeg())
            {
                var video = VideoInfo.FromFileInfo(file);

                FileInfo outputFile = new FileInfo(Path.GetTempFileName());

                encoder.OnProgress += (percentage) => Console.WriteLine("Transcoding video: Progress {0}%", percentage);

                VideoInfo convertedVideo = encoder.Convert(
                    video,
                    outputFile,
                    VideoType.Mp4,
                    Speed.UltraFast,
                    VideoSize.Original,
                    AudioQuality.Hd,
                    true
                );

                return convertedVideo.ToFileInfo();
            }
        }
        /// <summary>
        /// Strips EXIF metadata from images
        /// </summary>
        /// <param name="file">Must be an image</param>
        /// <returns>The same file, stripped of metadata</returns>
        public static FileInfo StripExif(this FileInfo file)
        {
            ExifLibrary.ImageFile image = ExifLibrary.ImageFile.FromFile(file.FullName);

            image.Properties.Clear();
            image.Save(file.FullName);

            return file;
        }
        /// <summary>
        /// Takes a file in memory and stores it as a temp file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The path to the file on disk</returns>
        public static async Task<FileInfo> CreateTempFile(this IFormFile file)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return new FileInfo(filePath);
        }
        /// <summary>
        /// Puts files in Blob storage
        /// </summary>
        /// <param name="file">A file on disk PROCESSED FIRST</param>
        /// <returns>A GUID representing the new name of the stored file</returns>
        public static async Task<string> StoreFile(FileInfo file)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            // TODO: Make container name an env variable
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("sk8m8-test");

            string fileName = Guid.NewGuid().ToString();
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading {0} to Blob storage as blob:\n\t {1}\n", fileName, blobClient.Uri);

            using (FileStream uploadFileStream = File.OpenRead(file.FullName))
            {
                await blobClient.UploadAsync(uploadFileStream);
            }

            file.Delete();

            return fileName;
        }
    }
}