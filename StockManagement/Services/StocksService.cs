using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class StocksService : IStocksService
    {
        private readonly IStockRepository _stocksRepository;

        public StocksService(IStockRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }

        public async Task<StockDTO> AddStock(StockCreateDTO stockCreateDTO)
        {
            Stock stock = await _stocksRepository.AddStock(stockCreateDTO.ToStock());

            return stock.ToStockDTO();
        }

        public async Task<StockDTO?> GetStockByItemID(int itemID)
        {
            Stock? stock = await _stocksRepository.GetStockByItemID(itemID);

            if (stock == null)
                return null;

            return stock.ToStockDTO();
        }

        public async Task<List<StockDTO>> GetStocks()
        {
            List<StockDTO> stocks = (await _stocksRepository.GetStocks())
                .Select(s => s.ToStockDTO())
                .ToList();

            return stocks;
        }

        public async Task<bool> RemoveStock(int itemID)
        {
            Stock? stock = await _stocksRepository.GetStockByItemID(itemID);

            if (stock == null)
                return false;

            await _stocksRepository.RemoveStock(stock);

            return true;
        }

        public async Task<StockDTO> UpdateStock(StockUpdateDTO stockUpdateDTO)
        {
            Stock stock = await _stocksRepository.UpdateStock(stockUpdateDTO.ToStock());

            return stock.ToStockDTO();
        }
    }
}
