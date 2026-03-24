using Microsoft.AspNetCore.Mvc;
using Pinkleaf_Collection.Dtabasecode;
using Pinkleaf_Collection.Models;

namespace Pinkleaf_Collection.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly AppDbContext _context;

        public UserHomeController(AppDbContext context)
        {
            _context = context;
        }
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
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Home");

            var user = _context.Users.Find(userId);

            ViewBag.Name = user.Name;
            ViewBag.Email = user.Email;
            ViewBag.Phone = user.Phone;
            ViewBag.Address = user.Address;

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
        // ================= EDIT PROFILE GET =================

        public IActionResult EditProfile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Home");

            var user = _context.Users.Find(userId);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(User model)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Home");

            var user = _context.Users.Find(userId);

            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.Address = model.Address;

                _context.SaveChanges();

                // SESSION UPDATE
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserPhone", user.Phone ?? "");
                HttpContext.Session.SetString("UserAddress", user.Address ?? "");
            }

            return RedirectToAction("MyAccount");
        }
    }
}


    
