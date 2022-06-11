using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class AttributeController : Controller
    {
        private readonly ECommerceDbContext _db;
        public AttributeController(ECommerceDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Models.Attribute> attributes = _db.Attributes.ToList();
            return View(attributes);
        }

        [HttpPost]
        public IActionResult Add(ECommerce.Models.Attribute attribute)
        {
            _db.Attributes.Add(attribute);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(ECommerce.Models.Attribute attribute)
        {
            if(_db.Attributes.Any(a => a.Id == attribute.Id))
            {
                _db.Attributes.Update(attribute);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(ECommerce.Models.Attribute attribute)
        {
            if(_db.Attributes.Any(a => a.Id == attribute.Id))
            {
                attribute = _db.Attributes.Find(attribute.Id);
                _db.Attributes.Remove(attribute);
                _db.SaveChanges();
            }            

            return RedirectToAction("Index");
        }
    }
}
