using _02_first_mvc_app.Data;
using _02_first_mvc_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace _02_first_mvc_app.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext context;

        public UsersController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            //...
            return View(context.Users.ToList());
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            // TODO: add validations
            if (!ModelState.IsValid) return View("Create");

            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);

            if (user == null) return NotFound(); // 404

            context.Users.Remove(user);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
