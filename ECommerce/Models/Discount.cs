using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
