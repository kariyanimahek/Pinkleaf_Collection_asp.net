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
      
    }
}
