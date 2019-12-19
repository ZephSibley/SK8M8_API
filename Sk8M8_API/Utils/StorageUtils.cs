using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Sk8M8_API
{
    // TODO: Configure Azure blob storage
    public class StorageUtils
    {
        public static async Task<string> StoreImageFile(IFormFile file)
        {
            // TODO: Strip EXIF

            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
        public static async Task<string> StoreVideoFile(IFormFile file)
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