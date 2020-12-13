using System;
using System.IO;
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
        User user = new User();
       [HttpPost]
        public IActionResult Register(string Username,int Password,int Password2,string Email, string DisplayName, string SecretKey)
        {
            if (Password == Password2)
            {
                foreach (var file in Request.Form.Files)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    user.ProfilePhotoData = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                    break;
                }

                string imageBase64Data = Convert.ToBase64String(user.ProfilePhotoData);
                string BannerImage = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

                user.Auth = "User";
                user.DisplayName = DisplayName;
                user.Email = Email;
                user.Password = Password;
                user.RegisterDate = DateTime.Now;
                user.SecretKey = SecretKey;
                user.Username = Username;
                user.ProfilePhoto = BannerImage;
               
                c.Users.Add(user);
                c.SaveChanges();
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return Content("Şifreler uyuşmuyor");
            }
            
        }
    }
}
