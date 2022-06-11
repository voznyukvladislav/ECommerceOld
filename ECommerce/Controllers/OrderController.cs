using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly ECommerceDbContext _db;
        public OrderController(ECommerceDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            /*OrderTest orderTest = new OrderTest(_db);
            for(int i = 0; i < 2; i++)
            {
                orderTest.GetOrder();
            }*/

            List<Order> orders = _db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Order_Products)
                .ThenInclude(o => o.Product)
                .ThenInclude(p => p.Product_Attributes)
                .ThenInclude(p => p.Attribute)
                .ToList();

            ViewBag.Orders = orders;

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(Order order)
        {
            if(_db.Orders.Any(o => o.Id == order.Id))
            {
                _db.Orders.Remove(order);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
