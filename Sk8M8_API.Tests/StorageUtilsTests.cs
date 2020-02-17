using FFMpegCore;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        [InlineData("testfile.jpg", ".jpg", ".png", ".jfif")]
        [InlineData("testfile.JPG", ".jpg", ".png", ".jfif")]
        [InlineData("testfile.png", ".jpg", ".png", ".jfif")]
        [Theory]
        public void ExtensionValidationSuccess(string fileName, params string[] permittedExtensions)
        {
            FileInfo file = new FileInfo(fileName);

            var result = StorageUtils.ValidateExtensions(file, permittedExtensions);
            Assert.IsType<bool>(result);
            Assert.True(result);
        }
        [InlineData("testfile.jpg", ".png")]
        [InlineData("testfile.JPG", ".JPG", ".PNG", ".JFIF")]
        [InlineData("testfile.png", ".jpg", ".jfif")]
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
