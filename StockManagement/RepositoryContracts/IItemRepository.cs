using Entities;

namespace RepositoryContracts
{
    public interface IItemRepository
    {
        Task<Item> AddItem(Item item);
        Task<List<Item>> GetItems();
        Task<Item> GetItemByID(int id);
        Task<Item> UpdateItem(Item item);
        Task<Item> DeleteItem(int id);
    }
}
