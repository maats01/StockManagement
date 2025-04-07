using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehiclesService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDTO> AddVehicle(VehicleCreateDTO vehicleCreateDTO)
        {
            Vehicle vehicle = await _vehicleRepository.AddVehicle(vehicleCreateDTO.ToVehicle());

            return vehicle.ToVehicleDTO();
        }

        public async Task<VehicleDTO?> GetVehicleByID(int id)
        {
            Vehicle? vehicle = await _vehicleRepository.GetVehicleByID(id);

            if (vehicle == null)
                return null;

            return vehicle.ToVehicleDTO();
        }

        public async Task<VehicleDTO?> GetVehicleByPlate(string plate)
        {
            Vehicle? vehicle = await _vehicleRepository.GetVehicleByPlate(plate);

            if (vehicle == null)
                return null;

            return vehicle.ToVehicleDTO();
        }

        public async Task<List<VehicleDTO>> GetVehicles()
        {
            List<VehicleDTO> vehicles = (await _vehicleRepository.GetVehicles())
                .Select(v => v.ToVehicleDTO())
                .ToList();

            return vehicles;
        }

        public async Task<bool> RemoveVehicle(int vehicleId)
        {
            Vehicle? vehicle = await _vehicleRepository.GetVehicleByID(vehicleId);

            if (vehicle == null)
                return false;

            await _vehicleRepository.RemoveVehicle(vehicle);
            
            return true;
        }

        public async Task<VehicleDTO> UpdateVehicle(VehicleUpdateDTO vehicleUpdateDTO)
        {
            Vehicle vehicle = await _vehicleRepository.UpdateVehicle(vehicleUpdateDTO.ToVehicle());

            return vehicle.ToVehicleDTO();
        }
    }
}
