using Microsoft.AspNetCore.Mvc;
using Pinkleaf_Collection.Models;

namespace Pinkleaf_Collection.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string email = "", string password = "")
        {
            ViewBag.Email = email;
            ViewBag.Password = password;
            return View();
        }

        // SIGN UP PAGE
        public IActionResult Register()
        {
            return View();
        }

        // SIGN UP POST
        [HttpPost]
        
        public IActionResult Register(RegisterViewModel model)
        {
            // abhi DB nahi, sirf redirect
            return RedirectToAction("Login", new
            {
                email = model.Email,
                password = model.Password
            });

            return View(model);
        }
                public IActionResult Register()
        {
            return View();
        }

      
        }
    
}
