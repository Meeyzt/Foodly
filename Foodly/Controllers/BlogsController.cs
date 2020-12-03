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
        public IActionResult WriteBlog(string Header,string restaurent,double star,int price,string Blog)
        {
            

            return View();
        }

    }
}
