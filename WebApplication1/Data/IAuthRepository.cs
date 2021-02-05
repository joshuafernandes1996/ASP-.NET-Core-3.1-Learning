using RPG_GAME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG_GAME.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password); //return userID
        Task<ServiceResponse<string>> Login(string username, string password); //return token
        Task<bool> UserExists(string username);
    }
}
