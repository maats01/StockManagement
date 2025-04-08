using Entities;

namespace ServiceContracts.DTO
{
    public class StockDTO
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public string? MeasureUnit { get; set; }
        public int MinimumStock { get; set; }
        public int MaximumStock { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public float Total { get; set; }
    }

    public static class ExtensionMethodsForStocks
    {
        public static StockDTO ToStockDTO(this Stock stock)
        {
            return new StockDTO()
            {
                ID = stock.ID,
                Description = stock.Description,
                MeasureUnit = stock.MeasureUnit,
                MinimumStock = stock.MinimumStock,
                MaximumStock = stock.MaximumStock,
                Quantity = stock.Quantity,
                Cost = stock.Cost,
                Total = stock.Cost * stock.Quantity
            };
        }
    }
}
