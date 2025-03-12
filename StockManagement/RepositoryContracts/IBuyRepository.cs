using Entities;

namespace RepositoryContracts
{
    public interface IBuyRepository
    {
        Task<Buy> AddBuy(Buy buy);
        Task<Buy> UpdateBuy(Buy buy);
        Task<List<Buy>> GetBuys();
        Task<Buy> GetBuyByID(int id);
        Task<Buy> DeleteBuy(int id);
        Task<BuyItem> AddBuyItem(int buyId, BuyItem buyItem);
        Task AddBuyItems(int buyId, List<BuyItem> buyItems);
        Task<List<BuyItem>> GetBuyItems(int buyId);
        Task<BuyItem> UpdateBuyItem(int buyId, BuyItem buyItem);
        Task<BuyItem> RemoveBuyItem(int buyId, BuyItem buyItem);
    }
}
