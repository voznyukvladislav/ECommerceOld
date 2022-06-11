using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ECommerceDbContext _db;
        public CategoryController(ECommerceDbContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if(_db.Categories.Any(c => c.Id == category.Id))
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(Category category)
        {
            if(_db.Categories.Any(c => c.Id == category.Id))
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
    }
}
