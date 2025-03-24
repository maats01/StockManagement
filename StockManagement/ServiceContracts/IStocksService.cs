using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Interface representing business logic for manipulating Stocks entity
    /// </summary>
    public interface IStocksService
    {
        /// <summary>
        /// Inserts a new stock in the database
        /// </summary>
        /// <param name="stockCreateDTO">Stock to add</param>
        /// <returns>The newly added stock as a StockDTO</returns>
        Task<StockDTO> AddStock(StockCreateDTO stockCreateDTO);
        /// <summary>
        /// Returns every stock in the database
        /// </summary>
        /// <returns>A List of StockDTO objects</returns>
        Task<List<StockDTO>> GetStocks();
        /// <summary>
        /// Returns a stock based on the given item ID
        /// </summary>
        /// <param name="itemID">ID to search</param>
        /// <returns>A StockDTO object</returns>
        Task<StockDTO?> GetStockByItemID(int itemID);
        /// <summary>
        /// Updates a stock in the database
        /// </summary>
        /// <param name="stockUpdateDTO">Stock to update</param>
        /// <returns>The newly updated stock as a StockDTO object</returns>
        Task<StockDTO> UpdateStock(StockUpdateDTO stockUpdateDTO);
        /// <summary>
        /// Removes a stock in the database based on the given item ID
        /// </summary>
        /// <param name="itemID">ID to search</param>
        /// <returns>True if removed; false otherwise</returns>
        Task<bool> RemoveStock(int itemID);
    }
}
