using Microsoft.AspNetCore.Mvc;

namespace PinkLeafCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
