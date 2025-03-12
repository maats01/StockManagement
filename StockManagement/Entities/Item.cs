using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [StringLength(25)]
        public string? MeasureUnit { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
    }
}
