using Microsoft.AspNetCore.Http;

namespace Sk8M8_API.DataClasses
{
    public class PointCreationRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IFormFile Video { get; set; }
    }
}
