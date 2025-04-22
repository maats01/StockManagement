using Entities;

namespace ServiceContracts.DTO
{
    public class ServiceOrderDTO
    {
        public int ID { get; set; }
        public float TotalProductValue { get; set; }
        public float TotalLabor { get; set; }
        public string? Description { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public VehicleDTO? Vehicle { get; set; }

        public List<ServiceItemDTO> ServiceItems { get; set; } = new List<ServiceItemDTO>();

        public ServiceOrderUpdateDTO ToServiceOrderUpdateDTO()
        {
            return new ServiceOrderUpdateDTO()
            {
                ID = ID,
                TotalProductValue = TotalProductValue,
                TotalLabor = TotalLabor,
                Description = Description,
                ServiceDate = ServiceDate,
                RegistrationDate = RegistrationDate,
                Vehicle = Vehicle,
                VehicleID = Vehicle.ID,
                ServiceItems = ServiceItems.Select(si => si.ToServiceItemUpdateDTO()).ToList()
            };
        }
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
                Description = so.Description,
                ServiceDate = so.ServiceDate,
                RegistrationDate = so.RegistrationDate,
                Vehicle = so.Vehicle?.ToVehicleDTO(),
                ServiceItems = so.ServiceItems.Select(si => si.ToServiceItemDTO()).ToList()
            };
        }
    }
}
