using Sk8M8_API.Enums;
using Bcrypt = BCrypt.Net.BCrypt;

namespace Sk8M8_API.Services
{

    public static class PasswordService
    {
        /// <summary>
        /// Hashes the password provided with BCrypt and returns it
        /// </summary>
        /// <param name="Password">Plaintext password provided by user</param>
        /// <returns>BCrypt Hashed password</returns>
        public static string HashPassword(string Password)
        {
            return Bcrypt.HashPassword(Password);
        }

        /// <summary>
        /// Checks that the provided password matches the hash provided
        /// </summary>
        /// <param name="Password">Plaintext password provided by the user</param>
        /// <param name="SourcePassword">Source password derived from user record</param>
        /// <returns>Result of the attempted validation</returns>
        public static ValidatePasswordStatus CheckPassword(string Password, string SourcePassword)
        {
            try
            {
                if (Bcrypt.Verify(Password, SourcePassword))
                {
                    return ValidatePasswordStatus.Valid;
                }
                else
                {
                    return ValidatePasswordStatus.Invalid;
                }
            }
            catch (BCrypt.Net.BcryptAuthenticationException)
            {
                return ValidatePasswordStatus.Error;
            }
        }
    }
}
