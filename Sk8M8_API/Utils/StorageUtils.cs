using Microsoft.AspNetCore.Http;
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
        /// Takes a file and stores it.
        /// Expects processing, e.g. virus scanning, to have been done already.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The path to the file in storage</returns>
        public static async Task<string> StoreFile(IFormFile file)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}