using Microsoft.AspNetCore.Mvc;

namespace PinkLeafCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Retail()
        {
            return View();
        }

        public IActionResult Wholesale()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();   // Session clear
            return RedirectToAction("Index", "Home"); // Landing Page
        }


    }
}
