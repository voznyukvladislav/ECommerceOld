using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class OrderTest
    {
        private ECommerceDbContext _db;
        public OrderTest(ECommerceDbContext db)
        {
            _db = db;
        }

        public Order GetOrder()
        {
            List<Product> products = _db.Products
                .Include(p => p.Product_Attributes)
                .ThenInclude(p => p.Attribute)
                .ToList();
            List<Order_Product> order_Products = new List<Order_Product>();

            User user = _db.Users.ToList()[0];
            Order order = new Order { Customer = user, OrderedAt = DateTime.Now, Price = 0, Order_Products = order_Products };

            Random random = new Random();
            int count = 0;
            for (int i = 0; i < products.Count; i++)
            {
                count = random.Next(1, 4);
                order_Products.Add(new Order_Product { Count = count, Order = order, OrderedPrice = products[i].Price * count, Product = products[i] });
                order.Price += order_Products[i].OrderedPrice;
            }

            _db.Orders.Add(order);
            _db.SaveChanges();

            return order;
        }
    }
}
