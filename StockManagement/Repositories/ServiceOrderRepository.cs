using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RepositoryContracts;

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
                .Include(s => s.ItemsService)
                    .ThenInclude(si => si.Item)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<List<ServiceOrder>> GetServiceOrders()
        {
            return await _db.ServiceOrders
                .Include(s => s.Vehicle)
                    .ThenInclude(v => v!.Owner)
                .Include(s => s.ItemsService)
                    .ThenInclude(si => si.Item)
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
            _db.ServiceItems.Update(serviceItem);
            await _db.SaveChangesAsync();

            return serviceItem;
        }

        public async Task<ServiceOrder> UpdateServiceOrder(ServiceOrder serviceOrder)
        {
            _db.ServiceOrders.Update(serviceOrder);
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
