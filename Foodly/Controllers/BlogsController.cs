using Microsoft.AspNetCore.Mvc;

namespace Foodly.Controllers
{
    public class BlogsController : Controller
    {
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
        public IActionResult WriteBlog(string Header,double star,string RestaurantName,string Price,string Blog)
        {
            string Header2 = Header;
            double star2 = star;
            string RestaurantName2 = RestaurantName;
            string Price2 = Price;
            string Blog2 = Blog;


            return View();
        }
    }
}
