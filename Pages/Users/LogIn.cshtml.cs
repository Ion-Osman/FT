using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiskeTorvet.Models;
using FiskeTorvet.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FiskeTorvet.Pages.Users
{
    [BindProperties]
    public class LogInModel : PageModel
    {
        IUserService userService;
        public string Username { get; set; }
        public string Password { get; set; }

        public LogInModel(IUserService service)
        {
            userService = service;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            return CheckLogin();
        }


        private IActionResult CheckLogin()
        {
            User validUser = userService.GetValidUser(Username, Password);
            if (validUser != null)
            {

                if (validUser.IsAdmin == true && validUser.Id != 0)
                {
                    // an admin
                    HttpContext.Session.SetString("admin", validUser.Username);
                    return Redirect("/Index");
                }
                else
                {
                    HttpContext.Session.SetString("normal", validUser.Username);
                    return Redirect("/Index");
                }
            }
            else
            {
                HttpContext.Session.SetString("Unregistered", "");
                return Redirect("~/Users/LogIn");
            }
        }
    }
}
