using System;
using Microsoft.EntityFrameworkCore;
using Moq.AutoMock;
using NetTopologySuite.Geometries;
using Sk8M8_API.Controllers;
using Sk8M8_API.Models;
using Xunit;

namespace Sk8M8_API.Tests.Controllers
{
    public class PeopleControllerTestBase
    {
        public PeopleControllerTestBase(DbContextOptions<SkateContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }

        protected DbContextOptions<SkateContext> ContextOptions { get; }

        protected const double Latitude = 1.1111;
        protected const double Longitude = -1.1111;
        private void Seed()
        {
            using (var context = new SkateContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                var point = new Point(Latitude, Longitude);
                var clientRecord = new Client()
                {
                    Username = "Bobby tables",
                    Password = "Password",
                    Email = "Bob@bob.tables",
                    Avatar = null,
                    Status = null,
                    Geolocation = point
                };
                context.Client.Add(clientRecord);
                context.SaveChanges();
            }
        }
    }
}