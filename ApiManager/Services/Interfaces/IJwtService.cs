using ApiManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiManager.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
