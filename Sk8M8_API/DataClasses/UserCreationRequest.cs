using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class UserCreationRequest
    {
        [Required]
        [StringLength(3, ErrorMessage = "Username is not long enough")]
        [Remote(action: "VerifyUsernameUniqueness", controller: "Account")]
        public string Username { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "Password is not long enough")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "VerifyEmailUniqueness", controller: "Account")]
        public string Email { get; set; }
    }
}
