using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Preset_Attribute
    {
        [Key]
        public int Id { get; set; }
        public Attribute Attribute { get; set; }
        public Preset Preset { get; set; }
    }
}
