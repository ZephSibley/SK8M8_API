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
        private SkateContext Context;

        public AccountController(SkateContext context)
        {
            this.Context = context;
        }

        public ActionResult Create(Models.Client Client)
        {
            var ClientRecord = new Client()
            {
                Username = Client.Username,
                Password = Services.PasswordService.HashPassword(Client.Password),
                Email = Client.Email
            };

            Context.Client.Add(Client);

            Context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }

        public ActionResult Login(Models.Client Client)
        {
            var RelevantUser = Context.Client.FirstOrDefault<Client>(x => x.Username == Client.Username);

            if(RelevantUser == null)
            {
                throw new Exception("This user doesn't exist");
            }

            var LoginSuccess = Services.PasswordService.CheckPassword(Client.Password, RelevantUser.Password);

            var LoginToken = new Resources.LoginTokenResource()
            {
                Token = null,
                Success = false
            };

            Services.SessionManagementService SessionManagement = new Services.SessionManagementService(RelevantUser);


            if (LoginSuccess == Enums.ValidatePasswordStatus.Valid)
            {
                LoginToken.Token = SessionManagement.Encode();
                LoginToken.Success = true;
            }

            Context.ClientLogin.Add(new ClientLogin() { Client = RelevantUser, IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString() });
            Context.SaveChanges();

            return Json(LoginToken);
        }
    }
}
