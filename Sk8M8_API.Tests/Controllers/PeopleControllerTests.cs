using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sk8M8_API.Controllers;
using Sk8M8_API.Models;
using Xunit;
using Newtonsoft.Json;

namespace Sk8M8_API.Tests.Controllers
{
    public class PeopleControllerTests : PeopleControllerTestBase
    {
        public PeopleControllerTests()
            : base(
                new DbContextOptionsBuilder<SkateContext>()
                    .UseInMemoryDatabase("test")
                    .Options)
        {
        }
        
        [Fact]
        public void FindSuccess()
        {
            using var context = new SkateContext(ContextOptions);
            
            var controller = new PeopleController(context);
            var findResult =  controller.Find(Latitude, Longitude, 10) as JsonResult;
            
            Assert.NotNull(findResult);
            
            var parsedResult =
                JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(findResult.Value))[0];
            
            Assert.Equal("Bobby tables", parsedResult.Username.Value);
            Assert.Equal(null, parsedResult.Avatar.Value);
            Assert.Equal(null, parsedResult.Status.Value);
        }
    }
}