using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class BuyOrderUpdateDTO
    {
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor total deve ser um número entre 1 e 100000")]
        public float TotalValue { get; set; }
        [StringLength(25)]
        public string? Status { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int SupplierID { get; set; }
        public PersonDTO? Supplier { get; set; }
        public List<BuyItemUpdateDTO> BuyItems { get; set; } = new List<BuyItemUpdateDTO>();

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
