using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sk8M8_API.Models;

namespace Sk8M8_API.Controllers
{
    public class PeopleController : Controller
    {
        private SkateContext Context { get; set; }
        public PeopleController(SkateContext context)
        {
            Context = context;
        }
        public ActionResult Find(
            double Latitude,
            double Longitude,
            double Radius
        )
        {
            var currentLocation = StorageUtils.CreateGeoPoint(Latitude, Longitude);

            var discoveredPeople = Context.Client
                .Where(row => row.Geolocation.IsWithinDistance(currentLocation, Radius))
                .Select(row => new { row.Avatar, row.Username, row.Status })
                .ToList();

            return Json(discoveredPeople);
        }
    }
}