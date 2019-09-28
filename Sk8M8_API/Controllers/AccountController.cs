using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sk8M8_API.Models;

namespace Sk8M8_API.Controllers
{
    public class AccountController : Controller 
    {
        private SkateContext _context;

        public AccountController(SkateContext context)
        {
            _context = context;
        }

        public ActionResult Create(Models.Client client)
        {
            var clientRecord = new Client()
            {
                Username = Client.Username,
                Password = Services.PasswordService.HashPassword(Client.Password),
                Email = Client.Email
            };

            _context.Client.Add(client);

            _context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }

        public ActionResult Login(Models.Client Client)
        {
            var relevantUser = _context.Client.FirstOrDefault<Client>(x => x.Username == Client.Username);

            if(relevantUser == null)
            {
                throw new Exception("This user doesn't exist");
            }

            var loginSuccess = Services.PasswordService.CheckPassword(Client.Password, relevantUser.Password);

            var loginToken = new Resources.LoginTokenResource()
            {
                Success = false
            };

            Services.SessionManagementService sessionManagement = new Services.SessionManagementService(relevantUser);

            if (loginSuccess == Enums.ValidatePasswordStatus.Valid)
            {
                sessionManagement.Authenticate();

                loginToken.Success = true;
            }

            _context.ClientLogin.Add(new ClientLogin() { Client = relevantUser, IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString() });
            _context.SaveChanges();

            return Json(loginToken);
        }
    }
}
