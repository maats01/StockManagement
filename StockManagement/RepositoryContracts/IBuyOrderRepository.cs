using Entities;

namespace RepositoryContracts
{
    public interface IBuyOrderRepository
    {
        Task<BuyOrder> AddBuy(BuyOrder buy);
        Task<BuyOrder> UpdateBuy(BuyOrder buy);
        Task<List<BuyOrder>> GetBuys();
        Task<BuyOrder?> GetBuyByID(int id);
        Task<BuyOrder> RemoveBuy(BuyOrder buy);
        Task<BuyItem> AddBuyItem(BuyItem buyItem);
        Task AddBuyItems(List<BuyItem> buyItems);
        Task<List<BuyItem>> GetBuyItemsByBuyID(int buyId);
        Task<BuyItem> UpdateBuyItem(BuyItem buyItem);
        Task<BuyItem> RemoveBuyItem(BuyItem buyItem);
    }
}
