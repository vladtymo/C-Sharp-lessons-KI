using Microsoft.AspNetCore.Mvc;

namespace _02_first_mvc_app.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            //...
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
