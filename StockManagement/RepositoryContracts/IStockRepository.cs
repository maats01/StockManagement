using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IStockRepository
    {
        Task<Stock> AddStock(Stock stock);
        Task<List<Stock>> GetStocks();
        Task<List<Stock>> GetFilteredStocks(Expression<Func<Stock, bool>> predicate);
        Task<Stock?> GetStockByItemID(int itemId);
        Task<Stock> UpdateStock(Stock stock);
        Task<Stock> RemoveStock(Stock stock);
    }
}
