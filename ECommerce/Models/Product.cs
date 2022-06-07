using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public List<Value> Values { get; set; }
        public Price Price { get; set; }
        public Discount Discount { get; set; }
    }
}
