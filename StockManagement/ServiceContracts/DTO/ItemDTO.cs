using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class ItemDTO
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "A descrição do item não pode ficar em branco")]
        public string? Description { get; set; }
        public string? MeasureUnit { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }

        public ItemUpdateDTO ToItemUpdateDTO()
        {
            return new ItemUpdateDTO()
            {
                ID = ID,
                Description = Description,
                MeasureUnit = MeasureUnit,
                MinimumStock = MinimumStock,
                MaximumStock = MaximumStock
            };
        }
    }

    public static class ExtensionMethodsForItem
    {
        public static ItemDTO ToItemDTO(this Item item)
        {
            return new ItemDTO()
            {
                ID = item.ID,
                Description = item.Description,
                MeasureUnit = item.MeasureUnit,
                MinimumStock = item.MinimumStock,
                MaximumStock = item.MaximumStock
            };
        }
    }
}
