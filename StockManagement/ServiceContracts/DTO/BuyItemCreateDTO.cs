using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class BuyItemCreateDTO
    {
        [Range(0.01, 10000, ErrorMessage = "O valor unitário deve ser um número entre 0.01 e 10000")]
        public float UnitValue { get; set; }
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser um número entre 1 e 10000")]
        public int Quantity { get; set; }

        public int BuyID { get; set; }
        public int ItemID { get; set; }

        public BuyItem ToBuyItem()
        {
            return new BuyItem()
            {
                UnitValue = UnitValue,
                Quantity = Quantity,
                BuyID = BuyID,
                ItemID = ItemID
            };
        }
    }
}
