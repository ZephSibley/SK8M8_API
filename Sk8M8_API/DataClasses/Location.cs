using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class Location
    {
        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Longitude { get; set; }
    }
}