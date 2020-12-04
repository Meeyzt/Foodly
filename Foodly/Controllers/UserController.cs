using System;
using Foodly.Models;
using Foodly.Models.EfModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Foodly.Controllers
{
    public class UserController : Controller
    {

        Context c = new Context();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, int Password)
        {
            User user = new User();
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string Username,int Password,string Email, string DisplayName, string SecretKey)
        {
            User user = new User() { Username = Username, Password = Password, Email = Email, DisplayName = DisplayName, SecretKey = SecretKey, RegisterDate = DateTime.Now, Auth = "1"};
            c.Users.Add(user);
            c.SaveChanges();
            return RedirectToAction(nameof(Login));
        }
    }
}
