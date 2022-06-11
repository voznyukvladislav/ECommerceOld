using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<Order_Product> Order_Products { get; set; }
        public User Customer { get; set; }
        public DateTime OrderedAt { get; set; }
        public decimal Price { get; set; }
    }
}
