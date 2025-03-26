using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class BuyOrderRepository : IBuyOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public BuyOrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BuyOrder> AddBuy(BuyOrder buy)
        {
            _db.BuyOrders.Add(buy);
            await _db.SaveChangesAsync();

            return buy;
        }

        public async Task<BuyItem> AddBuyItem(BuyItem buyItem)
        {
            _db.BuyItems.Add(buyItem);
            await _db.SaveChangesAsync();

            return buyItem;
        }

        public async Task AddBuyItems(List<BuyItem> buyItems)
        {
            foreach (BuyItem buyItem in buyItems)
            {
                _db.BuyItems.Add(buyItem);
            }

            await _db.SaveChangesAsync();
        }

        public async Task<BuyOrder> RemoveBuy(BuyOrder buy)
        {
            _db.BuyOrders.Remove(buy);
            await _db.SaveChangesAsync();

            return buy;
        }

        public async Task<BuyOrder?> GetBuyByID(int id)
        {
            return await _db.BuyOrders
                .Include(b => b.Supplier)
                .Include(b => b.BuyItems)
                    .ThenInclude(bi => bi.Item)
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<List<BuyItem>> GetBuyItemsByBuyOrderID(int buyId)
        {
            return await _db.BuyItems
                .Include(bi => bi.Item)
                .Where(b => b.BuyID == buyId)
                .ToListAsync();
        }

        public async Task<List<BuyOrder>> GetBuys()
        {
            return await _db.BuyOrders
                .Include(b => b.Supplier)
                .Include(b => b.BuyItems)
                    .ThenInclude(bi => bi.Item)
                .ToListAsync();
        }

        public async Task<BuyItem> RemoveBuyItem(BuyItem buyItem)
        {
            _db.BuyItems.Remove(buyItem);
            await _db.SaveChangesAsync();

            return buyItem;
        }

        public async Task<BuyOrder> UpdateBuy(BuyOrder buy)
        {
            _db.BuyOrders.Update(buy);
            await _db.SaveChangesAsync();

            return buy;
        }

        public async Task<BuyItem> UpdateBuyItem(BuyItem buyItem)
        {
            _db.BuyItems.Update(buyItem);
            await _db.SaveChangesAsync();

            return buyItem;
        }
    }
}
