using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class BuyOrderCreateDTO
    {
        [Range(1, 10000, ErrorMessage = "O valor total deve ser um número entre 1 e 100000")]
        public float TotalValue { get; set; }
        [StringLength(25)]
        public string? Status { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int SupplierID { get; set; }

        public List<BuyItemCreateDTO> BuyItems { get; set; } = new List<BuyItemCreateDTO>();

        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder()
            {
                TotalValue = TotalValue,
                Status = Status,
                BuyDate = BuyDate,
                RegistrationDate = RegistrationDate,
                SupplierID = SupplierID
            };
        }
    }
}
