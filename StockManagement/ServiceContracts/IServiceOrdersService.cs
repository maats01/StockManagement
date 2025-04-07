using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IServiceOrdersService
    {
        Task<ServiceOrderDTO> AddServiceOrder(ServiceOrderCreateDTO serviceOrderCreateDTO);
        Task<List<ServiceOrderDTO>> GetServiceOrders();
        Task<ServiceOrderDTO?> GetServiceOrderByID(int id);
        Task<bool> RemoveServiceOrder(int id);
        Task<ServiceOrderDTO> UpdateServiceOrder(ServiceOrderUpdateDTO serviceOrderUpdateDTO);
        Task AddServiceItems(List<ServiceItemCreateDTO> serviceItems);
        Task<ServiceItemDTO> UpdateServiceItem(ServiceItemUpdateDTO serviceItemUpdateDTO);
        Task<bool> RemoveServiceItem(int serviceOrderID, int itemID);
    }
}
