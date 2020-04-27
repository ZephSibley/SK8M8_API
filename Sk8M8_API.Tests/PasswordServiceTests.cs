using System;
using Xunit;
using Sk8M8_API.Services;

namespace Sk8M8_API.Tests
{
    public class PasswordServiceTests
    {

        [Fact]
        public void Hashing()
        {
            var password = Services.PasswordService.HashPassword("test string");
            Assert.IsType<string>(password);
        }
        [Fact]
        public void CheckingValid()
        {
            const string testString = "test string two";

            var password = Services.PasswordService.HashPassword(testString);
            Assert.IsType<string>(password);

            var checkSuccess = Services.PasswordService.CheckPassword(
                testString,
                password
            );
            Assert.StrictEqual<Enums.ValidatePasswordStatus>(
                Enums.ValidatePasswordStatus.Valid,
                checkSuccess
            );
        }
        [Fact]
        public void CheckingInvalid()
        {
            var password = Services.PasswordService.HashPassword("password");
            Assert.IsType<string>(password);

            var checkSuccess = Services.PasswordService.CheckPassword(
                "non-matching password",
                password
            );
            Assert.StrictEqual<Enums.ValidatePasswordStatus>(
                Enums.ValidatePasswordStatus.Invalid,
                checkSuccess
            );
        }
    }
}
