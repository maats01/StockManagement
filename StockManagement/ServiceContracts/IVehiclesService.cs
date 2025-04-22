using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IVehiclesService
    {
        Task<VehicleDTO> AddVehicle(VehicleCreateDTO vehicleCreateDTO);
        Task<VehicleDTO?> GetVehicleByID(int id);
        Task<VehicleDTO?> GetVehicleByPlate(string plate);
        Task<List<VehicleDTO>> GetFilteredVehicles(string searchBy, string searchString);
        Task<List<VehicleDTO>> GetVehicles();
        Task<VehicleDTO> UpdateVehicle(VehicleUpdateDTO vehicleUpdateDTO);
        Task<bool> RemoveVehicle(int vehicleId);
    }
}
