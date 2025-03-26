using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _db;

        public VehicleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            _db.Vehicles.Add(vehicle);
            await _db.SaveChangesAsync();

            return vehicle;
        }

        public async Task<Vehicle?> GetVehicleByID(int id)
        {
            return await _db.Vehicles.FirstOrDefaultAsync(v => v.ID == id);
        }

        public async Task<Vehicle?> GetVehicleByPlate(string plate)
        {
            return await _db.Vehicles.FirstOrDefaultAsync(v => v.Plate == plate);
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _db.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> RemoveVehicle(Vehicle vehicle)
        {
            _db.Vehicles.Remove(vehicle);
            await _db.SaveChangesAsync();

            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle vehicle)
        {
            _db.Vehicles.Update(vehicle);
            await _db.SaveChangesAsync();

            return vehicle;
        }
    }
}
