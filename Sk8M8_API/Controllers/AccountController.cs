﻿using Microsoft.AspNetCore.Authorization;
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
    public class AccountController : Controller
    {
        private SkateContext Context { get; set; }
        private readonly Services.ISessionManagementService _sessionManagementService;

        public AccountController(SkateContext context, Services.ISessionManagementService sessionManagementService)
        {
            Context = context;
            _sessionManagementService = sessionManagementService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create([FromBody] DataClasses.UserCreationRequest client)
        {
            Contract.Requires(client != null);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clientRecord = new Client()
            {
                Username = client.Username,
                Password = Services.PasswordService.HashPassword(client.Password),
                Email = client.Email,
                Avatar = null,
                Status = null
            };

            Context.Client.Add(clientRecord);

            Context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }

        [HttpPost]
        public ActionResult VerifyUsernameUniqueness(string username)
        {
            if (Context.Client.Any(x => x.Username == username))
            {
                return Json("Username already in use");
            }

            return Json(true);
        }

        [HttpPost]
        public ActionResult VerifyEmailUniqueness(string email)
        {
            if (Context.Client.Any(x => x.Email == email))
            {
                return Json("Email already in use");
            }

            return Json(true);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([FromBody] Client Client)
        {
            Contract.Requires(Client != null);

            var relevantUser = Context.Client.FirstOrDefault<Client>(x => x.Email == Client.Email);
            if (relevantUser != null)
            {
                var loginSuccess = Services.PasswordService.CheckPassword(Client.Password, relevantUser.Password);
                if (loginSuccess == Enums.ValidatePasswordStatus.Valid)
                {
                    Context.ClientLogin.Add(new ClientLogin() { Client = relevantUser, IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString() });
                    Context.SaveChanges();

                    return Json(
                        new Resources.LoginTokenResource()
                            {
                                JwtToken = _sessionManagementService.Authenticate(relevantUser),
                                Success = true
                            }
                        );
                }
            }

            return StatusCode(401);
        }
        [HttpGet]
        public ActionResult Me()
        {
            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            Client relevantUser = Context.Client.FirstOrDefault(x => x.Id == Convert.ToInt64(userClaim));

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
            var relevantUser = Context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));

            relevantUser.Geolocation = StorageUtils.CreateGeoPoint(latitude, longitude);

            Context.Client.Update(relevantUser);
            Context.SaveChanges();

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
            string[] permittedExtensions = { ".PNG", ".JPG" };

            var tempFile = await image.CreateTempFile();

            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            var relevantUser = Context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));

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
            Context.Client.Update(relevantUser);

            Context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }
        [HttpPost]
        public ActionResult UpdateStatus([FromBody] DataClasses.StatusUpdateRequest status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userClaim = User.FindFirstValue(ClaimTypes.Name);
            var relevantUser = Context.Client.FirstOrDefault<Client>(x => x.Id == Convert.ToInt64(userClaim));

            relevantUser.Status = status.Status;
            Context.Client.Update(relevantUser);
            Context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }
    }
}
