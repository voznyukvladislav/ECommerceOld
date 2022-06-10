using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Attribute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Preset_Attribute> Preset_Attributes { get; set; }
        public List<Product_Attribute> Product_Attributes { get; set; }
    }
}
