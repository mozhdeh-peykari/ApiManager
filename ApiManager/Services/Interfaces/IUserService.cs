using ApiManager.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiManager.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByUserAndPasswordAsync(string username, string password);
    }
}