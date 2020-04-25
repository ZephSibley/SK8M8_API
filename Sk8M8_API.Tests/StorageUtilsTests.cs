using NetTopologySuite.Geometries;
using System.IO;
using Xunit;

namespace Sk8M8_API.Tests
{
    public class StorageUtilsTests
    {
        [Fact]
        public void PointCreation()
        {
            var point = StorageUtils.CreateGeoPoint(51.1234, -1.3567);
            Assert.IsType<Point>(point);
        }
        [InlineData("testfile.JPG", ".JPG", ".PNG", ".JFIF")]
        [InlineData("testfile.jpg", ".JPG", ".PNG", ".JFIF")]
        [InlineData("testfile.PNG", ".JPG", ".PNG", ".JFIF")]
        [Theory]
        public void ExtensionValidationSuccess(string fileName, params string[] permittedExtensions)
        {
            FileInfo file = new FileInfo(fileName);

            var result = StorageUtils.ValidateExtensions(file, permittedExtensions);
            Assert.IsType<bool>(result);
            Assert.True(result);
        }
        [InlineData("testfile.JPG", ".PNG")]
        [InlineData("testfile.JPG", ".jpg", ".png", ".jfif")]
        [InlineData("testfile.png", ".JPG", ".JFIF")]
        [Theory]
        public void ExtensionValidationFailure(string fileName, params string[] permittedExtensions)
        {
            FileInfo file = new FileInfo(fileName);

            var result = StorageUtils.ValidateExtensions(file, permittedExtensions);
            Assert.IsType<bool>(result);
            Assert.False(result);
        }
    }
}
