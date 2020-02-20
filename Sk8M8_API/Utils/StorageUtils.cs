using Azure.Storage.Blobs;
using FFMpegCore;
using FFMpegCore.Enums;
using FFMpegCore.FFMPEG;
using FFMpegCore.FFMPEG.Enums;
using FFMpegCore.FFMPEG.Exceptions;
using Microsoft.AspNetCore.Http;
using nClam;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API
{
    public static class StorageUtils
    {
        /// <summary>
        /// Creates a database friendly location record using Postgresql net topology suite
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns>Point object</returns>
        public static Point CreateGeoPoint(double latitude, double longitude)
        {
            var point = new NetTopologySuite.Geometries.Point(latitude, longitude);

            return point;
        }
        public static bool ValidateExtensions(this FileInfo file, string[] permittedExtensions)
        {
            Contract.Requires(file != null);

            var fileExt = Path.GetExtension(file.Name).ToLowerInvariant();

            if (string.IsNullOrEmpty(fileExt) || !permittedExtensions.Contains(fileExt))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Wrapper for file to video type conversion
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The input file as FFMpeg VideoInfo type or null</returns>
        public static VideoInfo FileAsVideo(this FileInfo file)
        {
            VideoInfo videoFile = null;
            try
            {
                videoFile = VideoInfo.FromFileInfo(file);
            }
            catch (FFMpegException e)
            {
                Console.WriteLine("Error in FFMpeg processing \n {0}", e);
            }
            return videoFile;
        }
        /// <summary>
        /// Transcodes video files to mp4
        /// </summary>
        /// <param name="file">Video File</param>
        /// <returns>The transcoded file</returns>
        public static FileInfo Transcode(this VideoInfo video)
        {
            using (var encoder = new FFMpeg())
            {
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
            Contract.Requires(file != null);

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
            Contract.Requires(file != null);

            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return new FileInfo(filePath);
        }
        /// <summary>
        /// On-demand virus scanner for temp files.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>bool</returns>
        public static async Task<bool> FileIsSafe(this FileInfo file)
        {
            Contract.Requires(file != null);

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
        /// Puts files in Blob storage
        /// </summary>
        /// <param name="file">A file on disk PROCESSED FIRST</param>
        /// <returns>A GUID representing the new name of the stored file</returns>
        public static async Task<string> StoreFile(FileInfo file)
        {
            Contract.Requires(file != null);

            BlobServiceClient blobServiceClient = new BlobServiceClient(
                Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING")
            );
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(
                Environment.GetEnvironmentVariable("BLOB_STORAGE")
            );

            string fileName = Guid.NewGuid().ToString();
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            Console.WriteLine("Uploading {0} to Blob storage as blob:\n\t {1}\n", fileName, blobClient.Uri);

            using (FileStream uploadFileStream = File.OpenRead(file.FullName))
            {
                await blobClient.UploadAsync(uploadFileStream);
            }

            return fileName;
        }
    }
}