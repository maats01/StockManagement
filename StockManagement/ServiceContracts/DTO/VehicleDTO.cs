using Entities;

namespace ServiceContracts.DTO
{
    public class VehicleDTO
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public string? Plate { get; set; }
        public required PersonDTO Owner { get; set; }
        public List<ServiceOrderDTO> ServiceOrders { get; set; } = new List<ServiceOrderDTO>();

        public VehicleUpdateDTO ToUpdateDTO()
        {
            return new VehicleUpdateDTO()
            {
                ID = ID,
                Type = Type,
                Plate = Plate,
                Owner = Owner,
                OwnerID = Owner.ID
            };
        }
    }

    public static class ExtensionMethodsForVehicle
    {
        public static VehicleDTO ToVehicleDTO(this Vehicle vehicle)
        {
            return new VehicleDTO()
            {
                ID = vehicle.ID,
                Type = vehicle.Type,
                Plate = vehicle.Plate,
                Owner = vehicle.Owner!.ToPersonDTO(),
                ServiceOrders = vehicle.ServiceOrders.Select(so => so.ToServiceOrderDTO()).ToList()
            };
        }
    }
}
