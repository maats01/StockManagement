using Entities;

namespace RepositoryContracts
{
    public interface IBuyRepository
    {
        Task<Buy> AddBuy(Buy buy);
        Task<Buy> UpdateBuy(Buy buy);
        Task<List<Buy>> GetBuys();
        Task<Buy?> GetBuyByID(int id);
        Task<Buy> RemoveBuy(Buy buy);
        Task<BuyItem> AddBuyItem(BuyItem buyItem);
        Task AddBuyItems(List<BuyItem> buyItems);
        Task<List<BuyItem>> GetBuyItemsByBuyID(int buyId);
        Task<BuyItem> UpdateBuyItem(BuyItem buyItem);
        Task<BuyItem> RemoveBuyItem(BuyItem buyItem);
    }
}
