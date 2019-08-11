using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite;
using Sk8M8_API.Models;

namespace Sk8M8_API.Controllers
{
    public class MapMarkerController : Controller
    {
        private SkateContext Context { get; set; }

        public MapMarkerController(SkateContext context)
        {
            this.Context = context;
        }

        public ActionResult Create(
            string name,
            string description,
            double Latitude,
            double Longitude
        )
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var newMarker = new MapMarker()
            {
                Name = name,
                Description = description,
                Point = geometryFactory.CreatePoint(new GeoAPI.Geometries.Coordinate(Latitude, Longitude)),
                //Category = category, 
            };
            Context.MapMarker.Add(newMarker);
            Context.SaveChanges();

            return Json(new
            {
                success = true
            });
        }

        public ActionResult Find(
            double Latitude,
            double Longitude,
            double Radius
        )
        {
            // https://docs.microsoft.com/en-us/ef/core/modeling/spatial
            // https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-2.2
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var currentLocation = geometryFactory.CreatePoint(new GeoAPI.Geometries.Coordinate(Latitude, Longitude));

            var discoveredMarkers = Context.MapMarker
                .Where(row => row.Point.IsWithinDistance(currentLocation, Radius))
                .ToList();
            //.OrderBy(c => c.Location.Distance(currentLocation))
            return Json(discoveredMarkers);
        }
    }
}
