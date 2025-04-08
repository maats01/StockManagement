using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class ServiceItemUpdateDTO
    {
        public int ID { get; set; }
        public float UnitValue { get; set; }
        [Range(1, 10000, ErrorMessage = "O custo deve ser um número entre 1 e 10000")]
        public int Quantity { get; set; }

        public int ServiceOrderID { get; set; }
        public int ItemID { get; set; }
        public StockDTO? Item { get; set; }

        public ServiceItem ToServiceItem()
        {
            return new ServiceItem()
            {
                ID = ID,
                UnitValue = UnitValue,
                Quantity = Quantity,
                ServiceOrderID = ServiceOrderID,
                ItemID = ItemID
            };
        }
    }
}
