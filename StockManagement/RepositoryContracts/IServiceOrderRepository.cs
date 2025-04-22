using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IServiceOrderRepository
    {
        Task<ServiceOrder> AddServiceOrder(ServiceOrder serviceOrder);
        Task<ServiceOrder> UpdateServiceOrder(ServiceOrder serviceOrder);
        Task<List<ServiceOrder>> GetServiceOrders();
        Task<List<ServiceOrder>> GetFilteredServiceOrders(Expression<Func<ServiceOrder, bool>> predicate);
        Task<ServiceOrder?> GetServiceOrderByID(int id);
        Task<ServiceOrder> RemoveServiceOrder(ServiceOrder serviceOrder);
        Task<ServiceItem> AddServiceOrderItem(ServiceItem serviceItem);
        Task AddServiceItems(List<ServiceItem> serviceItems);
        Task<List<ServiceItem>> GetServiceItemsByServiceOrderId(int serviceOrderId);
        Task<ServiceItem?> GetServiceItemByID(int itemId, int serviceId);
        Task<ServiceItem> UpdateServiceItem(ServiceItem serviceItem);
        Task<ServiceItem> RemoveServiceItem(ServiceItem serviceItem);
    }
}
