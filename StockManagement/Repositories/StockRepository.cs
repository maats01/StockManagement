using Entities;
using RepositoryContracts;

namespace Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _db;

        public StockRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Stock> AddStock(Stock stock)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> DeleteStock(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Stock> GetStockByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Stock>> GetStocks()
        {
            throw new NotImplementedException();
        }

        public Task<Stock> UpdateStock(Stock stock)
        {
            throw new NotImplementedException();
        }
    }
}
