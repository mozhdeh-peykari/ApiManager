using ApiManager.Entities;
using System.Collections.Generic;

namespace ApiManager.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetByUserAndPassword(string username, string password);
        string GenerateToken(User user);
    }
}