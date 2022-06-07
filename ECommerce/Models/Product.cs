using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public Preset Preset { get; set; }
        public List<Value> Values { get; set; }
        public Discount Discount { get; set; }
    }
}
