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

        /// <summary>
        /// Create a Map Marker
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="Latitude"></param>
        /// <param name="Longitude"></param>
        /// <returns>Success Json object</returns>
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

        /// <summary>
        /// Finds all Map Markers within a radius to the given LatLong
        /// </summary>
        /// <param name="Latitude"></param>
        /// <param name="Longitude"></param>
        /// <param name="Radius"></param>
        /// <returns>List of MapMarker IDs and Coords</returns>
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
                .Select(row => new { row.Id, row.Point })
                .ToList();
            //.OrderBy(c => c.Location.Distance(currentLocation))
            return Json(discoveredMarkers);
        }

        /// <summary>
        /// Single Map Marker Entry
        /// </summary>
        /// <param name="id">Map Marker ID</param>
        /// <returns>All fields on one Map Marker</returns>
        public ActionResult Details(
            long id
        )
        {
            var markerDetail = Context.MapMarker
                .FirstOrDefault(row => row.Id == id);

            return Json(markerDetail);
        }
    }
}
