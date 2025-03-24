using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class StockCreateDTO
    {
        public int ItemID { get; set; }
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser um número entre 1 e 10000")]
        public int Quantity { get; set; }
        [Range(1, 10000, ErrorMessage = "O custo deve ser um número entre 1 e 10000")]
        public float Cost { get; set; }

        public Stock ToStock()
        {
            return new Stock()
            {
                ItemID = ItemID,
                Quantity = Quantity,
                Cost = Cost
            };
        }
    }
}
