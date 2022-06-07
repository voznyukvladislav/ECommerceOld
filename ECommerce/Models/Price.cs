using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public decimal PriceAmount { get; set; }
    }
}
