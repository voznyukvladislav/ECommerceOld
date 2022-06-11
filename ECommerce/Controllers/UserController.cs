using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly ECommerceDbContext _db;
        public UserController(ECommerceDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<User> users = _db.Users.ToList();

            return View(users);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(User user)
        {
            user = _db.Users.Find(user.Id);
            _db.Users.Remove(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
