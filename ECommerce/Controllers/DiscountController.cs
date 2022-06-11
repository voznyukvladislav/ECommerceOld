using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace ECommerce.Controllers
{
    public class DiscountController : Controller
    {
        private readonly ECommerceDbContext _db;
        public DiscountController(ECommerceDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Discount> discounts = _db.Discounts.ToList();

            return View(discounts);
        }

        [HttpPost]
        public IActionResult Add(Discount discount, string value)
        {
            decimal valueDec;
            Decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out valueDec);

            discount.Value = valueDec;

            _db.Discounts.Add(discount);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Discount discount, string value)
        {
            if(_db.Discounts.Any(d => d.Id == discount.Id))
            {
                decimal valueDec;
                Decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out valueDec);
                discount.Value = valueDec;

                _db.Discounts.Update(discount);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult Delete(Discount discount)
        {
            if(_db.Discounts.Any(d => d.Id == discount.Id))
            {
                discount = _db.Discounts.Find(discount.Id);
                _db.Discounts.Remove(discount);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
