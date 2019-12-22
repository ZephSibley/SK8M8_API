﻿using Microsoft.AspNetCore.Http;
using nClam;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API
{
    // TODO: Configure Azure blob storage
    public class StorageUtils
    {
        /// <summary>
        /// On-demand virus scanner for temp files.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>bool</returns>
        public static async Task<bool> FileIsSafe(string filePath)
        {
            var clam = new ClamClient("localhost", 3310);
            var scanResult = await clam.ScanFileOnServerAsync(filePath);

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
        /// Takes a file in memory and stores it as a temp file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The path to the file on disk</returns>
        public static async Task<FileInfo> StoreTempFile(this IFormFile file)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return new FileInfo(filePath);
        }
        public static async Task<FileInfo> StoreFile(FileInfo file)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return new FileInfo(filePath);
        }
    }
}