using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Linq.Expressions;

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
                .FirstOrDefaultAsync(s => s.ID == itemId);
        }

        public async Task<List<Stock>> GetStocks()
        {
            return await _db.Stocks
                .ToListAsync();
        }

        public async Task<List<Stock>> GetFilteredStocks(Expression<Func<Stock, bool>> predicate)
        {
            return await _db.Stocks
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<Stock> UpdateStock(Stock stock)
        {
            Stock existing = await _db.Stocks.FirstAsync(s => s.ID == stock.ID);

            existing.Description = stock.Description;
            existing.MinimumStock = stock.MinimumStock;
            existing.MaximumStock = stock.MaximumStock;
            existing.MeasureUnit = stock.MeasureUnit;
            existing.Quantity = stock.Quantity;
            existing.Cost = stock.Cost;

            await _db.SaveChangesAsync();

            return stock;
        }
    }
}
