using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class PointCreationRequest
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name length can't be more than 20 characters.")]
        public string Name { get; set; }

        [Required]
        [Remote(action: "VerifyLocationType", controller: "MapMarker")]
        public string Category { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Required]
        [Range(-90, 90)]
        public double Longitude { get; set; }

        // TODO: Validate
        public IFormFile Video { get; set; }
    }
}
