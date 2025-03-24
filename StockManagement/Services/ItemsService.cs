using ServiceContracts;
using ServiceContracts.DTO;
using RepositoryContracts;
using Entities;
using Services.Helpers;

namespace Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemRepository _itemsRepository;

        public ItemsService(IItemRepository itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public async Task<ItemDTO> AddItem(ItemCreateDTO itemCreateDTO)
        {
            Item item = await _itemsRepository.AddItem(itemCreateDTO.ToItem());

            return item.ToItemDTO();            
        }

        public async Task<ItemDTO?> GetItemByID(int id)
        {
            Item? item = await _itemsRepository.GetItemByID(id);

            if (item == null)
                return null;

            return item.ToItemDTO();
        }

        public async Task<List<ItemDTO>> GetItems()
        {
            List<ItemDTO> items = (await _itemsRepository.GetItems())
                .Select(i => i.ToItemDTO())
                .ToList();

            return items;
        }

        public async Task<bool> RemoveItem(int id)
        {
            Item? item = await _itemsRepository.GetItemByID(id);

            if (item == null)
                return false;
            
            await _itemsRepository.RemoveItem(item);

            return true;
        }

        public async Task<ItemDTO> UpdateItem(ItemUpdateDTO itemUpdateDTO)
        {
            Item item = await _itemsRepository.UpdateItem(itemUpdateDTO.ToItem());

            return item.ToItemDTO();
        }
    }
}
