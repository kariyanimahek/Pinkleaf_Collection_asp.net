using Microsoft.AspNetCore.Mvc;

namespace Pinkleaf_Collection.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email != "admin@gmail.com")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
