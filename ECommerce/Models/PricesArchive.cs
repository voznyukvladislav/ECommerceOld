using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class PricesArchive
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
