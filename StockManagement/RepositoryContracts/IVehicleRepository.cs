using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IVehicleRepository
    {
        Task<Vehicle> AddVehicle(Vehicle vehicle);
        Task<List<Vehicle>> GetVehicles();
        Task<List<Vehicle>> GetFilteredVehicles(Expression<Func<Vehicle, bool>> predicate);
        Task<Vehicle?> GetVehicleByID(int id);
        Task<Vehicle?> GetVehicleByPlate(string plate);
        Task<Vehicle> UpdateVehicle(Vehicle vehicle);
        Task<Vehicle> RemoveVehicle(Vehicle vehicle);
    }
}
