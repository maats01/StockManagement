using Entities;

namespace RepositoryContracts
{
    public interface IServiceOrderRepository
    {
        Task<ServiceOrder> AddServiceOrder(ServiceOrder serviceOrder);
        Task<ServiceOrder> UpdateServiceOrder(ServiceOrder serviceOrder);
        Task<List<ServiceOrder>> GetServiceOrders();
        Task<ServiceOrder> GetServiceOrderByID(int id);
        Task<ServiceOrder> DeleteServiceOrder(int id);
        Task<ServiceItem> AddServiceOrderItem(int serviceOrderId, ServiceItem serviceItem);
        Task AddServiceItems(int serviceOrderId, List<ServiceOrder> serviceItems);
        Task<List<ServiceItem>> GetServiceItems(int serviceOrderId);
        Task<ServiceItem> UpdateServiceItem(int serviceOrderId, ServiceItem serviceItem);
        Task<ServiceItem> RemoveServiceItem(int serviceOrderId, ServiceItem serviceItem);
    }
}
