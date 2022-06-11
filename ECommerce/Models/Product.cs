using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Preset Preset { get; set; }
        public List<Product_Attribute> Product_Attributes { get; set; }
        public Discount? Discount { get; set; }
    }
}
