using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IBuyOrdersService
    {
        Task<BuyOrderDTO> AddBuyOrder(BuyOrderCreateDTO buyOrderCreateDTO);
        Task<List<BuyOrderDTO>> GetBuyOrders();
        Task<BuyOrderDTO?> GetBuyOrderByID(int id);
        Task<bool> RemoveBuyOrder(int id);
        Task<BuyOrderDTO> UpdateBuyOrder(BuyOrderUpdateDTO buyOrderUpdateDTO);
        Task AddBuyItems(List<BuyItemCreateDTO> buyItems);
        Task<BuyItemDTO> UpdateBuyItem(BuyItemUpdateDTO buyItemUpdateDTO);
        Task<bool> RemoveBuyItem(int buyOrderID, int itemID);
    }
}
