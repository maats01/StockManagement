using Entities;
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

        public Task<Buy> AddBuy(Buy buy)
        {
            throw new NotImplementedException();
        }

        public Task<BuyItem> AddBuyItem(int buyId, BuyItem buyItem)
        {
            throw new NotImplementedException();
        }

        public Task AddBuyItems(int buyId, List<BuyItem> buyItems)
        {
            throw new NotImplementedException();
        }

        public Task<Buy> DeleteBuy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Buy> GetBuyByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BuyItem>> GetBuyItems(int buyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Buy>> GetBuys()
        {
            throw new NotImplementedException();
        }

        public Task<BuyItem> RemoveBuyItem(int buyId, BuyItem buyItem)
        {
            throw new NotImplementedException();
        }

        public Task<Buy> UpdateBuy(Buy buy)
        {
            throw new NotImplementedException();
        }

        public Task<BuyItem> UpdateBuyItem(int buyId, BuyItem buyItem)
        {
            throw new NotImplementedException();
        }
    }
}
