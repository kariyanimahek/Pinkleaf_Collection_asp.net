using Microsoft.AspNetCore.Mvc;
using Pinkleaf_Collection.Dtabasecode;
using Pinkleaf_Collection.Models;

namespace Pinkleaf_Collection.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        // ================= LOGIN =================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // ✅ OLD SESSION CLEAR
                HttpContext.Session.Clear();

                // ✅ NEW USER SESSION SET
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserPhone", user.Phone ?? "");
                HttpContext.Session.SetString("UserAddress", user.Address ?? "");

                return RedirectToAction("Index", "UserHome");
            }

            ViewBag.Error = "Invalid Login";
            return View();
        }


        // ================= REGISTER =================

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Name = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    Phone = model.Phone,
                    Address = model.Address
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }
    }
}
