using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Interface representing business logic for manipulating Item entity
    /// </summary>
    public interface IItemsService
    {
        /// <summary>
        /// Inserts a new Item in the database
        /// </summary>
        /// <param name="itemCreateDTO">Item to add</param>
        /// <returns>The newly added item as ItemDTO</returns>
        Task<ItemDTO> AddItem(ItemCreateDTO itemCreateDTO);
        /// <summary>
        /// Returns every item in the database
        /// </summary>
        /// <returns>A List of ItemDTO objects</returns>
        Task<List<ItemDTO>> GetItems();
        /// <summary>
        /// Returns a item based on the given ID
        /// </summary>
        /// <param name="id">ID to search</param>
        /// <returns>ItemDTO object or null</returns>
        Task<ItemDTO?> GetItemByID(int id);
        /// <summary>
        /// Updates a Item in the database
        /// </summary>
        /// <param name="itemUpdateDTO">Item to update</param>
        /// <returns>ItemDTO object with updated data</returns>
        Task<ItemDTO> UpdateItem(ItemUpdateDTO itemUpdateDTO);
        /// <summary>
        /// Removes a item based on the given ID
        /// </summary>
        /// <param name="id">ID to search</param>
        /// <returns>True if the item was removed correctly; if not, 
        /// returns False</returns>
        Task<bool> RemoveItem(int id);
    }
}
