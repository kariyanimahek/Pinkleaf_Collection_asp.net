using Microsoft.AspNetCore.Mvc;

namespace Pinkleaf_Collection.Controllers
{
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = HttpContext.Session.GetString("UserName");
            ViewBag.Email = HttpContext.Session.GetString("UserEmail");
            ViewBag.Phone = HttpContext.Session.GetString("UserPhone");

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
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult MyAccount()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Name = HttpContext.Session.GetString("UserName");
            ViewBag.Email = HttpContext.Session.GetString("UserEmail");
            ViewBag.Phone = HttpContext.Session.GetString("UserPhone");
            ViewBag.Address = HttpContext.Session.GetString("UserAddress");

            return View();
        }
        public IActionResult OrderSuccess()
        {
            return View();
        }
        public IActionResult MyOrders()
        {
            return View();
        }
        public IActionResult EditProfile()
        {
            return View();
        }


    }
}
