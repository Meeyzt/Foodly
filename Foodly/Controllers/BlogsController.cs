using Foodly.Models;
using Microsoft.AspNetCore.Mvc;
using Foodly.Models.EfModels;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Foodly.Controllers
{
    public class BlogsController : Controller
    {
        Context c = new Context();

        public DateTime Datetime { get; private set; }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Blog(int ?id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var blogContext = c.Reviews.Find(id);
                ViewData["blogContent"] = blogContext.Blog.ToString();
                ViewData["BlogHeader"] = blogContext.Header;
                ViewData["BlogPictureURL"] = blogContext.PictureURL;
                ViewData["BlogPrice"] = blogContext.Price;
                ViewData["BlogPublishDate"] = blogContext.PublishDate;
                ViewData["BlogRestaurantName"] = blogContext.RestaurantName;
                ViewData["BlogStar"] = blogContext.Star;
                ViewData["BlogUser"] = blogContext.User;

                return View();
            }
        }
        
        [HttpGet]
        public IActionResult WriteBlog()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WriteBlog(string Header,string restaurantName,double star,int price,string Blog,string PictureURL)
        {
            Review blog = new Review();
            blog.Header = Header;
            blog.Price = price;
            blog.Star = star;
            blog.Blog = Blog;
            blog.Publish = false;
            blog.RestaurantName = restaurantName;
            blog.PictureURL = "";
            blog.PublishDate = DateTime.Now;
            c.Reviews.Add(blog);
            c.SaveChanges();

            return View();
        }

    }
}
