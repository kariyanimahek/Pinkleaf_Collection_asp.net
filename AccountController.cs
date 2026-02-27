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
                .FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user != null)
            {
                // ✅ ALL SESSION VALUES SET KARO
                HttpContext.Session.SetString("UserName", user.Name ?? "");
                HttpContext.Session.SetString("UserEmail", user.Email ?? "");
                HttpContext.Session.SetString("UserPhone", user.Phone ?? "");
                HttpContext.Session.SetString("UserAddress", user.Address ?? "");

                if (user.Email == "admin@gmail.com")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "UserHome");
                }
            }

            ViewBag.Error = "Invalid Email or Password";
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
