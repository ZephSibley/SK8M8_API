using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class UserCreationRequest
    {
        [Required]
        [StringLength(15, ErrorMessage = "Username is too long")]
        [Remote(action: "VerifyUsernameUniqueness", controller: "Account")]
        public string Username { get; set; }

        [Required]
        [StringLength(101, ErrorMessage = "Password is too long")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "VerifyEmailUniqueness", controller: "Account")]
        public string Email { get; set; }
    }
}
