using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class ItemUpdateDTO
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "A descrição do item não pode ficar em branco")]
        public string? Description { get; set; }
        public string? MeasureUnit { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }

        public Item ToItem()
        {
            return new Item()
            {
                Description = Description,
                MeasureUnit = MeasureUnit,
                MinimumStock = MinimumStock,
                MaximumStock = MaximumStock
            };
        }
    }
}
