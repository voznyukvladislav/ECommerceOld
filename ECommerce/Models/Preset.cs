using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Preset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
