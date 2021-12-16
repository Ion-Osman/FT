using FiskeTorvet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Services.UserServices
{
    public interface IUserService
    {
        void AddUser(User user);

        User GetValidUser(string username, string pass);

        void RemoveUser(int id);

        List<User> GetUsers { get; }
    }
}
