using ApiManager.Common;
using ApiManager.Entities;
using ApiManager.Extensions;
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
            var user = users.SingleOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
                return null;

            return user;
        }
    }
}
