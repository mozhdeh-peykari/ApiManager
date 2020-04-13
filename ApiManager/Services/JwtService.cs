using ApiManager.Common;
using ApiManager.Entities;
using ApiManager.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Services
{
    public class JwtService : IJwtService
    {
        private readonly AppSettings appSettings;

        public JwtService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        public string GenerateToken(User user)
        {
            var secretKey = Encoding.ASCII.GetBytes(appSettings.JwtSettings.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.Now.AddMinutes(appSettings.JwtSettings.ExpirationMinutes),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
        }
    }
}
