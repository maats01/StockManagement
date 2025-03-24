using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class BuyItemDTO
    {
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor unitário deve ser um número entre 1 e 10000")]
        public float UnitValue { get; set; }
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser um número entre 1 e 10000")]
        public int Quantity { get; set; }
        public ItemDTO? Item { get; set; }

        public BuyItemUpdateDTO ToBuyItemUpdateDTO()
        {
            return new BuyItemUpdateDTO()
            {
                ID = ID,
                UnitValue = UnitValue,
                Quantity = Quantity,
                Item = Item
            };
        }
    }

    public static class ExtensionMethodsForBuyItem
    {
        public static BuyItemDTO ToBuyItemDTO(this BuyItem bi)
        {
            return new BuyItemDTO()
            {
                ID = bi.ID,
                UnitValue = bi.UnitValue,
                Quantity = bi.Quantity,
                Item = bi.Item?.ToItemDTO()
            };
        }
    }
}
