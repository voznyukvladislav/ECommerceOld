using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Value
    {
        [Key]
        public int Id { get; set; }
        public string Val { get; set; }
        public Attribute Attribute { get; set; }
        public Product Product { get; set; }
    }
}
