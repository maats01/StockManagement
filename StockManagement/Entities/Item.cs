using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Entity that represents a item
    /// </summary>
    public class Item
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "A descrição do item não pode ficar em branco")]
        public string? Description { get; set; }
        [StringLength(25)]
        public string? MeasureUnit { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
    }
}
