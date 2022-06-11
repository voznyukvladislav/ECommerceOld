using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Order_Product
    {
        [Key]
        public int Id { get; set; }
        public decimal OrderedPrice { get; set; }
        public int Count { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
