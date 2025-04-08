using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class StockCreateDTO
    {
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

        public Stock ToStock()
        {
            return new Stock()
            {
                Description = Description,
                MeasureUnit = MeasureUnit,
                MinimumStock = MinimumStock,
                MaximumStock = MaximumStock,
                Quantity = Quantity,
                Cost = Cost
            };
        }
    }
}
