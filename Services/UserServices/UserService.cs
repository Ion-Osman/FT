using FiskeTorvet.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiskeTorvet.Services.UserServices
{
    public class UserService : IUserService
    {
        private List<User> users;

        private JsonFileUserService JsonFileUserService;

        public UserService(JsonFileUserService jsonFileService)
        {
            JsonFileUserService = jsonFileService;
            users = JsonFileUserService.GetJsonUsers().ToList();
        }
        public List<User> GetUsers
        {
            get { return users; }
        }

        public void AddUser(User user)
        {
            user.Password = PasswordHash(user.Username, user.Password);
            users.Add(user);
            JsonFileUserService.SaveJsonUser(users);
        }
        public void RemoveUser(int id)
        {
            users.RemoveAt(id);
            JsonFileUserService.SaveJsonUser(users);

        }

        public User GetValidUser(string un, string ps)
        {
            User loggedIn = new User();
            foreach (var v in users)
            {
                if (v.Username == un)
                {
                    string jsonPassword = v.Password;
                    Microsoft.AspNetCore.Identity.PasswordHasher<string> pw = new PasswordHasher<string>();
                    var verificationResult = pw.VerifyHashedPassword(un, jsonPassword, ps);
                    if (verificationResult == PasswordVerificationResult.Success)
                        loggedIn = v;
                    else
                        loggedIn = null;
                    return loggedIn;
                }
            }
            return loggedIn;
        }
        private string PasswordHash(string userName, string password)
        {
            PasswordHasher<string> pw = new PasswordHasher<string>();
            string passwordHashed = pw.HashPassword(userName, password);
            return passwordHashed;
        }
    }
}
