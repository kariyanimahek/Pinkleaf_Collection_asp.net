using Microsoft.AspNetCore.Mvc;
using Pinkleaf_Collection.Models;

namespace Pinkleaf_Collection.Controllers
{
    public class AccountController : Controller
    {
        // ===== SINGLE LOGIN METHOD =====
        [HttpGet, HttpPost]
        public IActionResult Login(string email = "", string password = "")
        {
            // POST check
            if (Request.Method == "POST")
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    HttpContext.Session.SetString("UserEmail", email);
                    return RedirectToAction("Index", "UserHome");
                }

                ViewBag.Error = "Invalid login details";
            }

            // GET / first time load
            ViewBag.Email = email;
            ViewBag.Password = password;
            return View();
        }

        // REGISTER
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Login", new
            {
                email = model.Email,
                password = model.Password
            });
        }
    }
}
