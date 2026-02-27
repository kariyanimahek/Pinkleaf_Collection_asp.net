using Microsoft.AspNetCore.Mvc;

namespace pinkleaf_collection_.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult ProductList()
        {
            return View();
        }
        public IActionResult Wholesale()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult EditProfile()
        {
            return View();
        }
    }
}
