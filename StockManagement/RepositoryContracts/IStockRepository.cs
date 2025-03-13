using Entities;

namespace RepositoryContracts
{
    public interface IStockRepository
    {
        Task<Stock> AddStock(Stock stock);
        Task<List<Stock>> GetStocks();
        Task<Stock?> GetStockByItemID(int itemId);
        Task<Stock> UpdateStock(Stock stock);
        Task<Stock> RemoveStock(Stock stock);
    }
}
