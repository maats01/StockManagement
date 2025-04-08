using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Entity representing a stock of items
    /// </summary>
    public class Stock
    {
        [Key]
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser um número entre 1 e 10000")]
        [StringLength(50)]
        [Required(ErrorMessage = "A descrição do item não pode ficar em branco")]
        public string? Description { get; set; }
        [StringLength(25)]
        public string? MeasureUnit { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public int Quantity { get; set; }
        [Range(1, 10000, ErrorMessage = "O custo deve ser um número entre 1 e 10000")]
        public float Cost { get; set; }
    }
}
