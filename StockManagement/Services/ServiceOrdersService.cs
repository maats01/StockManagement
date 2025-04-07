using Entities;
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

        public async Task AddServiceItems(List<ServiceItemCreateDTO> serviceItems)
        {
            foreach (ServiceItemCreateDTO createDTO in serviceItems)
            {
                await _serviceOrderRepository.AddServiceOrderItem(createDTO.ToServiceItem());
            }
        }

        public async Task<ServiceOrderDTO> AddServiceOrder(ServiceOrderCreateDTO serviceOrderCreateDTO)
        {
            ServiceOrder serviceOrder = await _serviceOrderRepository.AddServiceOrder(serviceOrderCreateDTO.ToServiceOrder());

            return serviceOrder.ToServiceOrderDTO();
        }

        public async Task<ServiceOrderDTO?> GetServiceOrderByID(int id)
        {
            ServiceOrder? serviceOrder = await _serviceOrderRepository.GetServiceOrderByID(id);

            if (serviceOrder == null)
                return null;

            return serviceOrder.ToServiceOrderDTO();
        }

        public async Task<List<ServiceOrderDTO>> GetServiceOrders()
        {
            List<ServiceOrderDTO> serviceOrders = (await _serviceOrderRepository.GetServiceOrders())
                .Select(s => s.ToServiceOrderDTO())
                .ToList();

            return serviceOrders;
        }

        public async Task<bool> RemoveServiceItem(int serviceOrderID, int itemID)
        {
            ServiceItem? serviceItem = await _serviceOrderRepository.GetServiceItemByID(itemID, serviceOrderID);

            if (serviceItem == null)
                return false;

            await _serviceOrderRepository.RemoveServiceItem(serviceItem);
            return true;
        }

        public async Task<bool> RemoveServiceOrder(int id)
        {
            ServiceOrder? serviceOrder = await _serviceOrderRepository.GetServiceOrderByID(id);

            if (serviceOrder == null)
                return false;

            await _serviceOrderRepository.RemoveServiceOrder(serviceOrder);

            return true;
        }

        public async Task<ServiceItemDTO> UpdateServiceItem(ServiceItemUpdateDTO serviceItemUpdateDTO)
        {
            ServiceItem serviceItem = await _serviceOrderRepository.UpdateServiceItem(serviceItemUpdateDTO.ToServiceItem());

            return serviceItem.ToServiceItemDTO();
        }

        public async Task<ServiceOrderDTO> UpdateServiceOrder(ServiceOrderUpdateDTO serviceOrderUpdateDTO)
        {
            ServiceOrder serviceOrder = await _serviceOrderRepository.UpdateServiceOrder(serviceOrderUpdateDTO.ToServiceOrder());

            return serviceOrder.ToServiceOrderDTO();
        }
    }
}
