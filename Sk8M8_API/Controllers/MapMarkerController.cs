using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk8M8_API.Models;
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        /// <param name="marker"></param>
        /// <returns>Success Json object</returns>
        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody]
            DataClasses.PointCreationRequest marker
        )
        {
            Contract.Requires(marker != null);
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.SelectMany(
                    item => item.Value.Errors.Select(
                        error => error.ErrorMessage
                    )
                );
                return BadRequest(errorMessages);
            }
            
            var relevantCategory = Context.LocationType.FirstOrDefault(x => x.Name == marker.Category);
            if (relevantCategory == null) { return BadRequest("Invalid location category"); }

            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            var relevantUser = Context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));

            var markerPoint = StorageUtils.CreateGeoPoint(marker.Latitude, marker.Longitude);
            var proximityCheck = Context.MapMarker
                .Any(row => row.Point.IsWithinDistance(markerPoint, 0.0005));
            if (proximityCheck)
            {
                return BadRequest("Could not create: Too close to another marker.");
            }

            Media markerVideoRecord = null;
            if (marker.Video != null)
            {
                markerVideoRecord = await CreateMediaRecordForVideo(marker.Video, relevantUser);
                if (markerVideoRecord == null)
                {
                    return BadRequest("Video processing failed");
                }

                await Context.Media.AddAsync(markerVideoRecord);
            }

            var newMarkerRecord = new MapMarker()
            {
                Name = marker.Name,
                LocationCategory = marker.Category,
                Point = markerPoint,
                Video = markerVideoRecord,
                Creator = relevantUser,
            };
            var newMarkerCategoriesRecord = new MarkerCategory()
            {
                LocationType = relevantCategory,
                MapMarker = newMarkerRecord,
            };
            var newClientMarkersRecord = new ClientMarker()
            {
                User = relevantUser,
                MapMarker = newMarkerRecord,
            };
            var one = Context.ClientMarker.AddAsync(newClientMarkersRecord);
            var two = Context.MarkerCategory.AddAsync(newMarkerCategoriesRecord);
            var three = Context.MapMarker.AddAsync(newMarkerRecord);
            await one;
            await two;
            await three;
            await Context.SaveChangesAsync();
            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }
        /// <summary>
        /// Creates a Media Record for a video file, and stores that file in blob storage.
        /// </summary>
        /// <param name="file">A video file</param>
        /// <param name="user">Client record</param>
        /// <returns>A media record or null</returns>
        private async Task<Media> CreateMediaRecordForVideo(IFormFile file, Client user)
        {
            throw new NotImplementedException();
            /* var tempFile = await file.CreateTempFile();

            if (!await tempFile.FileIsSafe())
            {
                if (tempFile.Exists)
                {
                    tempFile.Delete();
                }
                return null;
            }

            // Both tempVideoFile and tempFile point at the same file
            var tempVideoFile = StorageUtils.FileAsVideo(tempFile);
            if (tempVideoFile == null || tempVideoFile.Duration.TotalSeconds > 10)
            {
                tempFile.Delete();
                return null;
            }

            var fileName = await StorageUtils.StoreFile(tempVideoFile.Transcode());
            tempFile.Delete();

            var newMedia = new Media()
            {
                Client = user,
                Filename = fileName
            };

            return newMedia; */
        }
        /// <summary>
        /// Finds all Map Markers within a radius to the given LatLong
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="radius"></param>
        /// <returns>List of MapMarker IDs and Coords</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Find(
            double latitude,
            double longitude,
            double radius
        )
        {
            var currentLocation = StorageUtils.CreateGeoPoint(latitude, longitude);

            var discoveredMarkers = Context.MapMarker
                .Where(row => row.Point.IsWithinDistance(currentLocation, radius))
                .Select(row => new { row.Id, coords = new double[] { row.Point.Coordinate.X, row.Point.Coordinate.Y } })
                .ToList();
            //.OrderBy(c => c.Location.Distance(currentLocation))
            return Json(discoveredMarkers);
        }
        /// <summary>
        /// Single Map Marker Entry
        /// </summary>
        /// <param name="id">Map Marker ID</param>
        /// <returns>All fields on one Map Marker</returns>
        [HttpGet]
        public ActionResult Details(
            long id
        )
        {
            var markerDetail = Context.MapMarker
                .Select(row => new
                {
                    row.Id,
                    row.Name,
                    row.LocationCategory,
                    row.Creator.Username,
                    starCount = row.ClientMarkerStars.Count
                })
                .FirstOrDefault(row => row.Id == id);

            return Json(markerDetail);
        }
        [HttpGet]
        public ActionResult LocationTypes()
        {
            var locationTypes = Context.LocationType
                .Select(row => row.Name)
                .ToList();

            return Json(locationTypes);
        }
        [HttpPost]
        public async Task<IActionResult> StarMarker(
            [FromQuery]
            int markerId
        )
        {
            var userClaim = Convert.ToInt64(User.FindFirstValue(ClaimTypes.Name));
            
            var hasStarred = Context.ClientMarkerStar.Any(
                x => x.ClientId == userClaim && x.MapMarkerId == markerId
            );
            if (hasStarred) { return BadRequest("You already did that"); }
            
            var newStar = new ClientMarkerStar
            {
                ClientId = userClaim,
                MapMarkerId = markerId,
            };

            await Context.ClientMarkerStar.AddAsync(newStar);
            await Context.SaveChangesAsync();
            return Json(
                new Resources.BaseResultResource() {Success = true}
            );
        }
        [HttpDelete]
        public async Task<IActionResult> UnstarMarker(
            [FromQuery]
            int markerId
        )
        {
            var userClaim = Convert.ToInt64(User.FindFirstValue(ClaimTypes.Name));

            var star = Context.ClientMarkerStar.FirstOrDefault(
                x => x.ClientId == userClaim && x.MapMarkerId == markerId);
            if (star == null) { return BadRequest("You already did that"); }

            Context.ClientMarkerStar.Remove(star);

            await Context.SaveChangesAsync();
            return Json(
                new Resources.BaseResultResource() {Success = true}
            );
        }
    }
}
