using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public List<Preset> Presets { get; set; }
    }
}
