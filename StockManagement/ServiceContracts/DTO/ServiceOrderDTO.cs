using Entities;

namespace ServiceContracts.DTO
{
    public class ServiceOrderDTO
    {
        public int ID { get; set; }
        public float TotalProductValue { get; set; }
        public float TotalLabor { get; set; }
        public string? Status { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Vehicle? Vehicle { get; set; }

        public List<ServiceItemDTO> ItemsService { get; set; } = new List<ServiceItemDTO>();
    }

    public static class ExtensionMethodsForServiceOrder
    {
        public static ServiceOrderDTO ToServiceOrderDTO(this ServiceOrder so)
        {
            return new ServiceOrderDTO()
            {
                ID = so.ID,
                TotalProductValue = so.TotalProductValue,
                TotalLabor = so.TotalLabor,
                Status = so.Status,
                ServiceDate = so.ServiceDate,
                RegistrationDate = so.RegistrationDate,
                Vehicle = so.Vehicle,
                ItemsService = so.ItemsService.Select(si => si.ToServiceItemDTO()).ToList()
            };
        }
    }
}
