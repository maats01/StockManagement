using ServiceContracts;
using ServiceContracts.DTO;
using RepositoryContracts;

namespace Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemRepository _itemsRepository;

        public ItemsService(IItemRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public Task<ItemDTO> AddItem(ItemCreateDTO? itemCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDTO?> GetItemByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemDTO>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ItemDTO> UpdateItem(ItemUpdateDTO? itemUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
