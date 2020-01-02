using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sk8M8_API.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sk8M8_API.Controllers
{
    public class AccountController : Controller
    {
        private SkateContext _context;
        private Services.ISessionManagementService _sessionManagementService;

        public AccountController(SkateContext context, Services.ISessionManagementService sessionManagementService)
        {
            _context = context;
            _sessionManagementService = sessionManagementService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create([FromBody] Client client)
        {
            var clientRecord = new Client()
            {
                Username = client.Username,
                Password = Services.PasswordService.HashPassword(client.Password),
                Email = client.Email,
                Avatar = "",
                Status = ""
            };

            _context.Client.Add(clientRecord);

            _context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([FromBody] Client Client)
        {
            var relevantUser = _context.Client.FirstOrDefault<Client>(x => x.Email == Client.Email);

            if (relevantUser == null)
            {
                throw new Exception("This user doesn't exist");
            }

            var loginSuccess = Services.PasswordService.CheckPassword(Client.Password, relevantUser.Password);

            var loginToken = new Resources.LoginTokenResource()
            {
                Success = false
            };

            if (loginSuccess == Enums.ValidatePasswordStatus.Valid)
            {
                loginToken.JwtToken = _sessionManagementService.Authenticate(relevantUser);

                loginToken.Success = true;
            }

            _context.ClientLogin.Add(new ClientLogin() { Client = relevantUser, IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString() });
            _context.SaveChanges();

            return Json(loginToken);
        }
        public ActionResult Me()
        {
            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            Client relevantUser = _context.Client.FirstOrDefault(x => x.Id == Convert.ToInt64(userClaim));

            return Json(
                new { relevantUser.Username, relevantUser.Avatar, relevantUser.Status }
            );
        }
        [HttpPost]
        public ActionResult UpdateLocation(
            [FromBody]
            double latitude,
            double longitude
        )
        {
            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            var relevantUser = _context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));

            relevantUser.Geolocation = StorageUtils.CreateGeoPoint(latitude, longitude);

            _context.Client.Update(relevantUser);
            _context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }
        [HttpPost]
        public async Task<ActionResult> UpdateAvatar(
            [FromBody]
            IFormFile image
            )
        {
            string[] permittedExtensions = { ".png", ".jpg" };

            var tempFile = await image.CreateTempFile();

            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            var relevantUser = _context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));

            if (
                relevantUser == null ||
                !await tempFile.FileIsSafe() ||
                !tempFile.ValidateExtensions(permittedExtensions)
                )
            {
                if (tempFile.Exists)
                {
                    tempFile.Delete();
                }

                return Json(
                    new Resources.BaseResultResource() { Success = false }
                );
            }

            var fileName = await StorageUtils.StoreFile(tempFile.StripExif());
            tempFile.Delete();

            relevantUser.Avatar = fileName;
            _context.Client.Update(relevantUser);

            _context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }
        [HttpPost]
        public ActionResult UpdateStatus([FromBody] string status)
        {
            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            var relevantUser = _context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));

            relevantUser.Status = status;
            _context.Client.Update(relevantUser);
            _context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }
    }
}
