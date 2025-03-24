using AutoFixture;
using Entities;
using FluentAssertions;
using Moq;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace Tests
{
    public class StockServiceTests
    {
        private readonly IStocksService _stocksService;
        private readonly IStockRepository _stocksRepository;
        private readonly Mock<IStockRepository> _stocksRepositoryMock;
        private readonly IFixture _fixture;

        public StockServiceTests()
        {
            _fixture = new Fixture();

            _stocksRepositoryMock = new Mock<IStockRepository>();
            _stocksRepository = _stocksRepositoryMock.Object;

            _stocksService = new StocksService(_stocksRepository);
        }

        public Stock BuildExampleStock()
        {
            return _fixture.Create<Stock>();
        }

        #region AddStock

        [Fact]
        public async Task AddStock_ValidCreateDTO_ToBeSuccessful()
        {
            StockCreateDTO stockCreateDTO = _fixture.Create<StockCreateDTO>();
            Stock stock = stockCreateDTO.ToStock();
            StockDTO expected = stock.ToStockDTO();

            _stocksRepositoryMock
                .Setup(t => t.AddStock(It.IsAny<Stock>()))
                .ReturnsAsync(stock);

            StockDTO actual = await _stocksService.AddStock(stockCreateDTO);

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetStocks

        [Fact]
        public async Task GetStocks_EmptyListByDefault()
        {
            List<Stock> stocks = new List<Stock>();

            _stocksRepositoryMock
                .Setup(t => t.GetStocks())
                .ReturnsAsync(stocks);

            List<StockDTO> response = await _stocksService.GetStocks();

            response.Should().BeEmpty();
        }

        [Fact]
        public async Task GetStocks_NotEmptyList()
        {
            List<Stock> stocks = new List<Stock>() 
            {
                BuildExampleStock(), BuildExampleStock(), BuildExampleStock()
            };

            List<StockDTO> expectedStocks = stocks.Select(s => s.ToStockDTO()).ToList();

            _stocksRepositoryMock
                .Setup(t => t.GetStocks())
                .ReturnsAsync(stocks);

            List<StockDTO> response = await _stocksService.GetStocks();

            response.Should().BeEquivalentTo(expectedStocks);
        }

        #endregion

        #region GetStockByItemID

        [Fact]
        public async Task GetStockByItemID_InvalidID_ToBeNull()
        {
            StockDTO? response = await _stocksService.GetStockByItemID(55);

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetStockByItemID_ValidID_ToBeSuccessful()
        {
            Stock stock = BuildExampleStock();
            StockDTO expected = stock.ToStockDTO(); 

            _stocksRepositoryMock
                .Setup(t => t.GetStockByItemID(It.IsAny<int>()))
                .ReturnsAsync(stock);

            StockDTO? actual = await _stocksService.GetStockByItemID(stock.ItemID);

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region UpdateStock

        [Fact]
        public async Task UpdateStock_ValidUpdateDTO_ToBeSuccessful()
        {
            StockUpdateDTO stockUpdateDTO = _fixture.Create<StockUpdateDTO>();
            Stock stock = stockUpdateDTO.ToStock();
            StockDTO expected = stock.ToStockDTO();

            _stocksRepositoryMock
                .Setup(t => t.UpdateStock(It.IsAny<Stock>()))
                .ReturnsAsync(stock);

            StockDTO response = await _stocksService.UpdateStock(stockUpdateDTO);

            response.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region RemoveStock

        [Fact]
        public async Task RemoveStock_InvalidID_ToBeFalse()
        {
            _stocksRepositoryMock
                .Setup(t => t.GetStockByItemID(It.IsAny<int>()))
                .ReturnsAsync(null as Stock);

            bool isRemoved = await _stocksService.RemoveStock(55);

            isRemoved.Should().BeFalse();
        }

        [Fact]
        public async Task RemoveStock_InvalidID_ToBeTrue()
        {
            Stock stock = BuildExampleStock();

            _stocksRepositoryMock
                .Setup(t => t.GetStockByItemID(It.IsAny<int>()))
                .ReturnsAsync(stock);

            _stocksRepositoryMock
                .Setup(t => t.RemoveStock(It.IsAny<Stock>()))
                .ReturnsAsync(stock);

            bool isRemoved = await _stocksService.RemoveStock(stock.ItemID);

            isRemoved.Should().BeTrue();
        }

        #endregion
    }
}
