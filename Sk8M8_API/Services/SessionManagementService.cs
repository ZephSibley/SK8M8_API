using Microsoft.IdentityModel.Tokens;
using Sk8M8_API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sk8M8_API.Services
{
    public class SessionManagementService : ISessionManagementService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public SessionManagementService()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string Authenticate(Client client)
        {
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, client.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }
    }
}
