using Entities;

namespace RepositoryContracts
{
    public interface IStockRepository
    {
        Task<Stock> AddStock(Stock stock);
        Task<List<Stock>> GetStocks();
        Task<Stock> GetStockByID(int id);
        Task<Stock> UpdateStock(Stock stock);
        Task<Stock> DeleteStock(int id);
    }
}
