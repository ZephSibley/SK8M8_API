﻿using System.Collections.Generic;
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
            
            Assert.Equal<long>(1, parsedResult.Id.Value);
            Assert.Equal<double>(Latitude, parsedResult.coords[0].Value);
            Assert.Equal<double>(Longitude, parsedResult.coords[1].Value);
        }
    }
}