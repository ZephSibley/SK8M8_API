using System.ComponentModel.DataAnnotations;

namespace Sk8M8_API.DataClasses
{
    public class ChangePasswordRequest : ClientPasswordRequest
    {
        [Required]
        public string OldPassword { get; set; }
    }
}