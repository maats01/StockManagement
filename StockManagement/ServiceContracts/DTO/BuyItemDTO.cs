using Entities;

namespace ServiceContracts.DTO
{
    public class BuyItemDTO
    {
        public int ID { get; set; }
        public float UnitValue { get; set; }
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
