using Entities;
using RepositoryContracts;

namespace Repositories
{
    class ServiceOrderRepository : IServiceOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task AddServiceItems(int serviceOrderId, List<ServiceOrder> serviceItems)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrder> AddServiceOrder(ServiceOrder serviceOrder)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceItem> AddServiceOrderItem(int serviceOrderId, ServiceItem serviceItem)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrder> DeleteServiceOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceItem>> GetServiceItems(int serviceOrderId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrder> GetServiceOrderByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceOrder>> GetServiceOrders()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceItem> RemoveServiceItem(int serviceOrderId, ServiceItem serviceItem)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceItem> UpdateServiceItem(int serviceOrderId, ServiceItem serviceItem)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrder> UpdateServiceOrder(ServiceOrder serviceOrder)
        {
            throw new NotImplementedException();
        }
    }
}
