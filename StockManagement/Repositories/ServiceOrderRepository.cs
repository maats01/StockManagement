using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RepositoryContracts;
using System.Linq.Expressions;

namespace Repositories
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddServiceItems(List<ServiceItem> serviceItems)
        {
            foreach (ServiceItem serviceItem in serviceItems)
            {
                _db.ServiceItems.Add(serviceItem);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<ServiceOrder> AddServiceOrder(ServiceOrder serviceOrder)
        {
            _db.ServiceOrders.Add(serviceOrder);
            await _db.SaveChangesAsync();

            return serviceOrder;
        }

        public async Task<ServiceItem> AddServiceOrderItem(ServiceItem serviceItem)
        {
            _db.ServiceItems.Add(serviceItem);
            await _db.SaveChangesAsync();

            return serviceItem;
        }

        public async Task<ServiceOrder> RemoveServiceOrder(ServiceOrder serviceOrder)
        {
            _db.ServiceOrders.Remove(serviceOrder);
            await _db.SaveChangesAsync();

            return serviceOrder;
        }

        public async Task<List<ServiceItem>> GetServiceItemsByServiceOrderId(int serviceOrderId)
        {
            return await _db.ServiceItems
                .Include(si => si.Item)
                .Where(s => s.ServiceOrderID == serviceOrderId)
                .ToListAsync();
        }

        public async Task<ServiceOrder?> GetServiceOrderByID(int id)
        {
            return await _db.ServiceOrders
                .Include(s => s.Vehicle)
                    .ThenInclude(v => v!.Owner)
                .Include(s => s.ServiceItems)
                    .ThenInclude(si => si.Item)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<List<ServiceOrder>> GetServiceOrders()
        {
            return await _db.ServiceOrders
                .Include(s => s.Vehicle)
                    .ThenInclude(v => v!.Owner)
                .Include(s => s.ServiceItems)
                    .ThenInclude(si => si.Item)
                .ToListAsync();
        }

        public async Task<List<ServiceOrder>> GetFilteredServiceOrders(Expression<Func<ServiceOrder, bool>> predicate)
        {
            return await _db.ServiceOrders
                .Include(s => s.Vehicle)
                    .ThenInclude(v => v.Owner)
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<ServiceItem> RemoveServiceItem(ServiceItem serviceItem)
        {
            _db.ServiceItems.Remove(serviceItem);
            await _db.SaveChangesAsync();

            return serviceItem;
        }

        public async Task<ServiceItem> UpdateServiceItem(ServiceItem serviceItem)
        {
            ServiceItem? matching = await _db.ServiceItems.FirstOrDefaultAsync(si => si.ItemID == serviceItem.ItemID && si.ServiceOrderID == serviceItem.ServiceOrderID);

            if (matching == null)
            {
                _db.ServiceItems.Add(serviceItem);
                await _db.SaveChangesAsync();
            }

            matching = await _db.ServiceItems.FirstAsync(si => si.ItemID == serviceItem.ItemID && si.ServiceOrderID == serviceItem.ServiceOrderID);

            matching.Quantity = serviceItem.Quantity;
            matching.UnitValue = serviceItem.UnitValue;
            matching.ItemID = serviceItem.ItemID;

            await _db.SaveChangesAsync();

            return serviceItem;
        }

        public async Task<ServiceOrder> UpdateServiceOrder(ServiceOrder serviceOrder)
        {
            ServiceOrder matching = await _db.ServiceOrders.FirstAsync(so => so.ID == serviceOrder.ID);

            matching.ServiceDate = serviceOrder.ServiceDate;
            matching.TotalLabor = serviceOrder.TotalLabor;
            matching.TotalProductValue = serviceOrder.TotalProductValue;
            matching.Description = serviceOrder.Description;
            matching.VehicleID = serviceOrder.VehicleID;

            await _db.SaveChangesAsync();

            return serviceOrder;
        }

        public async Task<ServiceItem?> GetServiceItemByID(int itemId, int serviceId)
        {
            return await _db.ServiceItems
                .Include(s => s.Item)
                .FirstOrDefaultAsync(s => s.ItemID == itemId && s.ServiceOrderID == serviceId);
        }
    }
}
