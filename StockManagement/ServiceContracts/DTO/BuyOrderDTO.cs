using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class BuyOrderDTO
    {
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor total deve ser um número entre 1 e 100000")]
        public float TotalValue { get; set; }
        [StringLength(25)]
        public string? Status { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public PersonDTO? Supplier { get; set; }
        public List<BuyItemDTO> BuyItems { get; set; } = new List<BuyItemDTO>();

        public BuyOrderUpdateDTO ToBuyOrderUpdateDTO()
        {
            return new BuyOrderUpdateDTO()
            {
                ID = ID,
                TotalValue = TotalValue,
                Status = Status,
                BuyDate = BuyDate,
                RegistrationDate = RegistrationDate,
                Supplier = Supplier,
                BuyItems = BuyItems.Select(bi => bi.ToBuyItemUpdateDTO()).ToList()
            };
        }
    }

    public static class ExtensionMethodsForBuyOrder
    {
        public static BuyOrderDTO ToBuyOrderDTO(this BuyOrder bo)
        {
            return new BuyOrderDTO()
            {
                ID = bo.ID,
                TotalValue = bo.TotalValue,
                Status = bo.Status,
                BuyDate = bo.BuyDate,
                RegistrationDate = bo.RegistrationDate,
                Supplier = bo.Supplier?.ToPersonDTO(),
                BuyItems = bo.BuyItems.Select(bi => bi.ToBuyItemDTO()).ToList()
            };
        }
    }
}
