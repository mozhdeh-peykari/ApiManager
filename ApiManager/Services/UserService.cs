using ApiManager.Common;
using ApiManager.Entities;
using ApiManager.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        public List<User> users = new List<User> {
                new User { Id = 1, Username="mojpey",Password="123",FirstName="Mozhdeh",LastName="Peykari"},
                new User { Id = 2, Username = "na3rfaraji", Password = "456", FirstName = "Nasser", LastName = "Faraji" }
                };
        public IEnumerable<User> GetAll()
        {
            return users;
        }
        public User GetByUserAndPassword(string username, string password)
        {
            return users.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
        public string GenerateToken(User user)
        {
            var secretKey = Encoding.ASCII.GetBytes(appSettings.JwtSettings.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, user.Id.ToString())
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
