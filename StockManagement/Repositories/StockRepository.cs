using Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Stock> AddStock(Stock stock)
        {
            _db.Stocks.Add(stock);
            await _db.SaveChangesAsync();

            return stock;
        }

        public async Task<Stock> RemoveStock(Stock stock)
        {
            _db.Stocks.Remove(stock);
            await _db.SaveChangesAsync();

            return stock;
        }

        public async Task<Stock?> GetStockByItemID(int itemId)
        {
            return await _db.Stocks
                .Include(s => s.Item)
                .FirstOrDefaultAsync(s => s.ItemID == itemId);
        }

        public async Task<List<Stock>> GetStocks()
        {
            return await _db.Stocks
                .Include(s => s.Item)
                .ToListAsync();
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            _db.Stocks.Update(stock);
            await _db.SaveChangesAsync();

            return stock;
        }
    }
}
