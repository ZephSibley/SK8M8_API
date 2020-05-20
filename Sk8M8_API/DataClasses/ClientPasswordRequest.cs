using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class ClientPasswordRequest
    {
        [Required]
        [StringLength(9999, ErrorMessage = "Password is too short", MinimumLength = 6)]
        public string Password { get; set; }
    }
}