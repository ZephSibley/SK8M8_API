using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Sk8M8_API.Enums;
using Sk8M8_API.DataClasses;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Sk8M8_API.Models;

namespace Sk8M8_API.Services
{
    public class SessionManagementService : ISessionManagementService
    {
        private AppSettings _appSettings;
        private JwtSecurityTokenHandler _tokenHandler;

        public SessionManagementService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public void Authenticate(Client client)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, client.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            _tokenHandler.WriteToken(token);
        }
    }
}
