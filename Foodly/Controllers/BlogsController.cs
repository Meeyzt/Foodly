using Foodly.Models;
using Microsoft.AspNetCore.Mvc;
using Foodly.Models.EfModels;
using System;

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
        public IActionResult Blog1()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult WriteBlog()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult WriteBlog(string Header,string restaurantName,double star,int price,string Blog)
        {
            Review blog = new Review();
            blog.Header = Header;
            blog.Price = price;
            blog.Star = star;
            blog.Blog = Blog;
            blog.Publish = false;
            blog.RestaurantName = restaurantName;
            blog.PictureURL = "www.google.com";
            blog.PublishDate = DateTime.Now;
            c.Reviews.Add(blog);
            c.SaveChanges();

            return View();
        }

    }
}
