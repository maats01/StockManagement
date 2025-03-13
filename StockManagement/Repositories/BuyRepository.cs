using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;

namespace Repositories
{
    public class BuyRepository : IBuyRepository
    {
        private readonly ApplicationDbContext _db;

        public BuyRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Buy> AddBuy(Buy buy)
        {
            _db.Purchases.Add(buy);
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

        public async Task<Buy> RemoveBuy(Buy buy)
        {
            _db.Purchases.Remove(buy);
            await _db.SaveChangesAsync();

            return buy;
        }

        public async Task<Buy?> GetBuyByID(int id)
        {
            return await _db.Purchases
                .Include(b => b.Supplier)
                .Include(b => b.BuyItems)
                    .ThenInclude(bi => bi.Item)
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<List<BuyItem>> GetBuyItemsByBuyID(int buyId)
        {
            return await _db.BuyItems
                .Include(bi => bi.Item)
                .Where(b => b.BuyID == buyId)
                .ToListAsync();
        }

        public async Task<List<Buy>> GetBuys()
        {
            return await _db.Purchases
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

        public async Task<Buy> UpdateBuy(Buy buy)
        {
            _db.Purchases.Update(buy);
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
