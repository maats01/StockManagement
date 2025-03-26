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

        public Task<VehicleDTO> AddVehicle(VehicleCreateDTO vehicleCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDTO?> GetVehicleByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDTO?> GetVehicleByPlate(string plate)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleDTO>> GetVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveVehicle(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDTO> UpdateVehicle(VehicleUpdateDTO vehicleUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
