using Entities;

namespace ServiceContracts.DTO
{
    public class ServiceItemDTO
    {
        public int ID { get; set; }
        public float UnitValue { get; set; }
        public int Quantity { get; set; }
        public StockDTO? Item { get; set; }
    }

    public static class ExtensionMethodsForServiceItem
    {
        public static ServiceItemDTO ToServiceItemDTO(this ServiceItem si)
        {
            return new ServiceItemDTO()
            {
                ID = si.ID,
                UnitValue = si.UnitValue,
                Quantity = si.Quantity,
                Item = si.Item?.ToStockDTO()
            };
        }
    }
}
