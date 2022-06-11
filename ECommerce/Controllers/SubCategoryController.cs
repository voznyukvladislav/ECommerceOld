using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ECommerceDbContext _db;
        public SubCategoryController(ECommerceDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            List<SubCategory> subCategories = _db.SubCategories.ToList();

            ViewBag.Categories = categories;
            ViewBag.SubCategories = subCategories;

            return View();
        }

        [HttpPost]
        public IActionResult Add(SubCategory subCategory)
        {
            Category category = _db.Categories.Find(subCategory.Category.Id);
            subCategory.Category = category;
            
            _db.SubCategories.Add(subCategory);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(SubCategory subCategory)
        {
            if(_db.SubCategories.Any(sc => sc.Id == subCategory.Id))
            {
                Category category = _db.Categories.Find(subCategory.Category.Id);
                subCategory.Category = category;

                _db.SubCategories.Update(subCategory);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(SubCategory subCategory)
        {
            if(_db.SubCategories.Any(sc => sc.Id == subCategory.Id))
            {
                subCategory = _db.SubCategories.Find(subCategory.Id);
                _db.SubCategories.Remove(subCategory);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }
    }
}
