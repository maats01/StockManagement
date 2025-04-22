using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq.Expressions;

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
            return await _db.Vehicles
                .Include(v => v.Owner)
                .FirstOrDefaultAsync(v => v.ID == id);
        }

        public async Task<Vehicle?> GetVehicleByPlate(string plate)
        {
            return await _db.Vehicles.FirstOrDefaultAsync(v => v.Plate == plate);
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await _db.Vehicles
                .Include(v => v.Owner)
                .ToListAsync();
        }

        public async Task<List<Vehicle>> GetFilteredVehicles(Expression<Func<Vehicle, bool>> predicate)
        {
            return await _db.Vehicles
                .Where(predicate)
                .Include(v => v.Owner)
                .ToListAsync();
        }

        public async Task<Vehicle> RemoveVehicle(Vehicle vehicle)
        {
            _db.Vehicles.Remove(vehicle);
            await _db.SaveChangesAsync();

            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle vehicle)
        {
            Vehicle existing = await _db.Vehicles.FirstAsync(v => v.ID == vehicle.ID);

            existing.Plate = vehicle.Plate;
            existing.OwnerID = vehicle.OwnerID;
            existing.Type = vehicle.Type;

            await _db.SaveChangesAsync();

            return vehicle;
        }
    }
}
