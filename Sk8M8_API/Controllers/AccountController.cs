﻿using System;
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
        private Services.ISessionManagementService _sessionManagementService;

        public AccountController(SkateContext context, Services.ISessionManagementService sessionManagementService)
        {
            _context = context;
            _sessionManagementService = sessionManagementService;
        }

        public ActionResult Create([FromBody] Client client)
        {
            var clientRecord = new Client()
            {
                Username = client.Username,
                Password = Services.PasswordService.HashPassword(client.Password),
                Email = client.Email
            };

            _context.Client.Add(clientRecord);

            _context.SaveChanges();

            return Json(
                new Resources.BaseResultResource() { Success = true }
            );
        }

        public ActionResult Login([FromBody] Client Client)
        {
            var relevantUser = _context.Client.FirstOrDefault<Client>(x => x.Email == Client.Email);

            if(relevantUser == null)
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
                _sessionManagementService.Authenticate(relevantUser);

                loginToken.Success = true;
            }

            _context.ClientLogin.Add(new ClientLogin() { Client = relevantUser, IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString() });
            _context.SaveChanges();

            return Json(loginToken);
        }
    }
}
