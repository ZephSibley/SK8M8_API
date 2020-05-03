using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class UserCreationRequest
    {
        [Required]
        [StringLength(26, ErrorMessage = "Username is too long")]
        public string Username { get; set; }

        [Required]
        [StringLength(101, ErrorMessage = "Password is too long", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
