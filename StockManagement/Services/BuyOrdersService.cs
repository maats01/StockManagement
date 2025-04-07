using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class BuyOrdersService : IBuyOrdersService
    {
        private readonly IBuyOrderRepository _buyOrdersRepository;

        public BuyOrdersService(IBuyOrderRepository buyOrdersRepository)
        {
            _buyOrdersRepository = buyOrdersRepository;
        }

        public async Task AddBuyItems(List<BuyItemCreateDTO> buyItems)
        {
            foreach (BuyItemCreateDTO createDTO in buyItems)
            {
                await _buyOrdersRepository.AddBuyItem(createDTO.ToBuyItem());
            }
        }

        public async Task<BuyOrderDTO> AddBuyOrder(BuyOrderCreateDTO buyOrderCreateDTO)
        {
            BuyOrder buyOrder = await _buyOrdersRepository.AddBuy(buyOrderCreateDTO.ToBuyOrder());

            return buyOrder.ToBuyOrderDTO();
        }

        public async Task<BuyOrderDTO?> GetBuyOrderByID(int id)
        {
            BuyOrder? buyOrder = await _buyOrdersRepository.GetBuyByID(id);

            if (buyOrder == null)
            {
                return null;
            }

            return buyOrder.ToBuyOrderDTO();
        }

        public async Task<List<BuyOrderDTO>> GetBuyOrders()
        {
            List<BuyOrderDTO> buyOrders = (await _buyOrdersRepository.GetBuys())
                .Select(b => b.ToBuyOrderDTO())
                .ToList();

            return buyOrders;
        }

        public async Task<bool> RemoveBuyItem(int buyOrderID, int itemID)
        {
            BuyItem? buyItem = await _buyOrdersRepository.GetBuyItemByID(itemID, buyOrderID);

            if (buyItem == null)
                return false;

            await _buyOrdersRepository.RemoveBuyItem(buyItem);

            return true;
        }

        public async Task<bool> RemoveBuyOrder(int id)
        {
            BuyOrder? buyOrder = await _buyOrdersRepository.GetBuyByID(id);

            if (buyOrder == null)
                return false;

            await _buyOrdersRepository.RemoveBuy(buyOrder);

            return true;
        }

        public async Task<BuyItemDTO> UpdateBuyItem(BuyItemUpdateDTO buyItemUpdateDTO)
        {
            BuyItem buyItem = await _buyOrdersRepository.UpdateBuyItem(buyItemUpdateDTO.ToBuyItem());

            return buyItem.ToBuyItemDTO();
        }

        public async Task<BuyOrderDTO> UpdateBuyOrder(BuyOrderUpdateDTO buyOrderUpdateDTO)
        {
            BuyOrder buyOrder = await _buyOrdersRepository.UpdateBuy(buyOrderUpdateDTO.ToBuyOrder());

            return buyOrder.ToBuyOrderDTO();
        }
    }
}
