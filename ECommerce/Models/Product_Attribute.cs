using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product_Attribute
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public Attribute Attribute { get; set; }
        public Product Product { get; set; }
    }
}
