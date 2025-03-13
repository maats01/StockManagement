using Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Item> AddItem(Item item)
        {
            _db.Items.Add(item);
            await _db.SaveChangesAsync();

            return item;
        }

        public async Task<Item> RemoveItem(Item item)
        {
            _db.Items.Remove(item);
            await _db.SaveChangesAsync();

            return item;
        }

        public async Task<Item?> GetItemByID(int id)
        {
            return await _db.Items.FirstOrDefaultAsync(i => i.ID == id);
        }

        public async Task<List<Item>> GetItems()
        {
            return await _db.Items.ToListAsync();
        }

        public async Task<Item> UpdateItem(Item item)
        {
            _db.Items.Update(item);
            await _db.SaveChangesAsync();

            return item;
        }
    }
}
