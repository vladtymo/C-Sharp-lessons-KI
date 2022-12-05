using _02_first_mvc_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_first_mvc_app.Controllers
{
    public class UsersController : Controller
    {
        static private List<User> users = new List<User>()
        {
            new User() {Id = 1, Name = "Bob", Email = "saper@gmail.com", BirthDate = DateTime.Now},
            new User() {Id = 2, Name = "Vlad", Email = "blabla@gmail.com", BirthDate = DateTime.Now},
            new User() {Id = 3, Name = "John", Email = "mister@ukr.net", BirthDate = DateTime.Now},
            new User() {Id = 4, Name = "Lilia", Email = "developer@gmail.com", BirthDate = DateTime.Now}
        };

        public IActionResult Index()
        {
            //...
            return View(users);
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null) return NotFound(); // 404

            users.Remove(user);

            return RedirectToAction("Index");
        }
    }
}
