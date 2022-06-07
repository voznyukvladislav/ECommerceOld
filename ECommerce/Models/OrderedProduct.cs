using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class OrderedProduct
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
