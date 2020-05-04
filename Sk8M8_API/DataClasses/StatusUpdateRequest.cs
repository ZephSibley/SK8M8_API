using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class StatusUpdateRequest
    {
        [Required]
        [StringLength(150, ErrorMessage = "Status is too long")]
        public string Status { get; set; }
    }
}
