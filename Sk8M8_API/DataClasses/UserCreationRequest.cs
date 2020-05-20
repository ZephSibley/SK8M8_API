using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class UserCreationRequest : ClientPasswordRequest
    {
        [Required]
        [StringLength(26, ErrorMessage = "Username is too long")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
