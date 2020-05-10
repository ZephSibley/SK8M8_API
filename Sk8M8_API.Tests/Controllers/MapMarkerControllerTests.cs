using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sk8M8_API.Controllers;
using Sk8M8_API.Models;
using Xunit;
using Newtonsoft.Json;


namespace Sk8M8_API.Tests.Controllers
{
    public class MapMarkerControllerTests : MapMarkerControllerTestBase
    {
        public MapMarkerControllerTests()
            : base(
                new DbContextOptionsBuilder<SkateContext>()
                    .UseInMemoryDatabase("AccountTest")
                    .Options)
        {
        }
        
        [Fact]
        public void FindSuccess()
        {
            using var context = new SkateContext(ContextOptions);
            var sessionManagement = new Services.SessionManagementService();

            var controller = new MapMarkerController(context);
            var findResult =  controller.Find(Latitude, Longitude, 10) as JsonResult;
            
            Assert.NotNull(findResult);
            
            var parsedResult =
                JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(findResult.Value))[0];
            
            Assert.NotEmpty(parsedResult);
            Assert.Equal<long>(1, parsedResult.Id.Value);
            Assert.Equal<double>(Latitude, parsedResult.coords[0].Value);
            Assert.Equal<double>(Longitude, parsedResult.coords[1].Value);
        }
        // [Fact]
        // public void GetMarkerDetails()
        // {
        //     using var context = new SkateContext(ContextOptions);
        //
        //     var controller = new MapMarkerController(context);
        //     var findResult =  controller.Details(1) as JsonResult;
        //     
        //     Assert.NotNull(findResult);
        //     
        //     var parsedResult =
        //         JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(findResult.Value));
        //     
        //     Assert.Equal("Place", parsedResult.Name.Value);
        //     Assert.Equal("SkatePark", parsedResult.LocationCategory.Value);
        //     Assert.Equal<long>(1, parsedResult.Id.Value);
        //     Assert.Equal("Bobby tables", parsedResult.Username.Value);
        // }
        [Fact]
        public void GetLocationTypes()
        {
            using var context = new SkateContext(ContextOptions);

            var controller = new MapMarkerController(context);
            var findResult =  controller.LocationTypes() as JsonResult;
            
            Assert.NotNull(findResult);
            
            var parsedResult =
                JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(findResult.Value));
            
            Assert.NotEmpty(parsedResult);
            Assert.Equal("SkatePark", parsedResult[0]);
        }
    }
}