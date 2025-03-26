using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class ServiceOrdersService : IServiceOrdersService
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public ServiceOrdersService(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }

        public Task<List<ServiceItemDTO>> AddServiceItems(List<ServiceItemCreateDTO> serviceItems)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrderDTO> AddServiceOrder(ServiceOrderCreateDTO serviceOrderCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrderDTO?> GetServiceOrderByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceOrderDTO>> GetServiceOrders()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveServiceItem(int serviceOrderID, int itemID)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceItemDTO> UpdateServiceItem(ServiceItemUpdateDTO serviceItemUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceOrderDTO> UpdateServiceOrder(ServiceOrderUpdateDTO serviceOrderUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
