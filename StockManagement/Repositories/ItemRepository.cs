using Entities;
using RepositoryContracts;

namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Item> AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<Item> UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
