using Entities;

namespace ServiceContracts.DTO
{
    public class StockDTO
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }

        public ItemDTO? Item { get; set; }
    }

    public static class ExtensionMethodsForStocks
    {
        public static StockDTO ToStockDTO(this Stock stock)
        {
            return new StockDTO()
            {
                ItemID = stock.ItemID,
                Quantity = stock.Quantity,
                Cost = stock.Cost,
                Item = stock.Item?.ToItemDTO()
            };
        }
    }
}
