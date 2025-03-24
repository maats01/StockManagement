using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class BuyOrdersService : IBuyOrderService
    {
        private readonly IBuyOrderRepository _buyOrdersRepository;

        public BuyOrdersService(IBuyOrderRepository buyOrdersRepository)
        {
            _buyOrdersRepository = buyOrdersRepository;
        }

        public Task<List<BuyItemDTO>> AddBuyItems(List<BuyItemCreateDTO> buyItems)
        {
            throw new NotImplementedException();
        }

        public Task<BuyOrderDTO> AddBuyOrder(BuyOrderCreateDTO buyOrderCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BuyOrderDTO?> GetBuyOrderByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BuyOrderDTO>> GetBuyOrders()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveBuyItem(int buyItemID, int itemID)
        {
            throw new NotImplementedException();
        }

        public Task<BuyItemDTO> UpdateBuyItem(BuyItemUpdateDTO buyItemUpdateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BuyOrderDTO> UpdateBuyOrder(BuyOrderUpdateDTO buyOrderUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
