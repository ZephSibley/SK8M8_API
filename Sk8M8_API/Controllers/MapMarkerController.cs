using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk8M8_API.Models;
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody]
            DataClasses.PointCreationRequest marker
        )
        {
            Contract.Requires(marker != null);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            var relevantUser = Context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));
            var relevantCategory = Context.LocationType.FirstOrDefault<LocationType>(x => x.Name == marker.Category);

            var markerPoint = StorageUtils.CreateGeoPoint(marker.Latitude, marker.Longitude);
            var proximityCheck = Context.MapMarker
                .Where(row => row.Point.IsWithinDistance(markerPoint, 0.0005))
                .Any();
            if (proximityCheck)
            {
                return Json(new
                {
                    success = false,
                    msg = "Could not create: Too close to another marker."
                });
            }

            Media markerVideoRecord = null;
            if (marker.Video != null)
            {
                markerVideoRecord = await CreateMediaRecordForVideo(marker.Video, relevantUser);
                if (markerVideoRecord == null) 
                {
                    return Json(new Resources.ResultResource() {
                        Success = false,
                        Msg = "Video processing failed"
                    });
                }

                Context.Media.Add(markerVideoRecord);
            }

            var newMarkerRecord = new MapMarker()
            {
                Name = marker.Name,
                LocationCategory = marker.Category,
                Point = markerPoint,
                Video = markerVideoRecord,
                Creator = relevantUser,
            };
            Context.MapMarker.Add(newMarkerRecord);

            var newMarkerCategoriesRecord = new MarkerCategory()
            {
                LocationType = relevantCategory,
                MapMarker = newMarkerRecord,
            };
            Context.MarkerCategory.Add(newMarkerCategoriesRecord);

            var newClientMarkersRecord = new ClientMarker()
            {
                User = relevantUser,
                MapMarker = newMarkerRecord,
            };
            Context.ClientMarker.Add(newClientMarkersRecord);

            Context.SaveChanges();

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
        [HttpGet]
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
            var currentLocation = StorageUtils.CreateGeoPoint(Latitude, Longitude);

            var discoveredMarkers = Context.MapMarker
                .Where(row => row.Point.IsWithinDistance(currentLocation, Radius))
                .Select(row => new { row.Id, coords = new double[] { row.Point.Coordinate.X, row.Point.Coordinate.Y } })
                .ToList();
            //.OrderBy(c => c.Location.Distance(currentLocation))
            return Json(discoveredMarkers);
        }
        [HttpGet]
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
                .Select(row => new { row.Id, row.Name, row.LocationCategory, row.Creator.Username })
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
        public ActionResult VerifyLocationType(string locationType)
        {
            var relevantCategory = Context.LocationType.First<LocationType>(x => x.Name == locationType);
            if (relevantCategory == null) { return Json($"Location type \"{locationType}\" not recognised."); }

            return Json(true);
        }
    }
}
