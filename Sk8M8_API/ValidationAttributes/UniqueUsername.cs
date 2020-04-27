using System.ComponentModel.DataAnnotations;
using System.Linq;
using Sk8M8_API.Models;

namespace Sk8M8_API.ValidationAttributes
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        private SkateContext Context { get; }
        private string Username { get; }

        public UniqueUsernameAttribute(SkateContext context, string username)
        {
            Context = context;
            Username = username;
        }
        private string GetErrorMessage() =>
            $"\"{Username}\" is already taken.";
        
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            return Context.Client.Any(x => x.Username == Username) ?
                new ValidationResult(GetErrorMessage()) : ValidationResult.Success;
        }
    }
}