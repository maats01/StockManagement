using AutoFixture;
using Moq;
using RepositoryContracts;
using ServiceContracts;
using Services;

namespace Tests
{
    public class BuyOrderServiceTests
    {
        private readonly IBuyOrdersService _buyOrderService;
        private readonly IBuyOrderRepository _buyOrderRepository;
        private readonly Mock<IBuyOrderRepository> _buyOrderRepositoryMock;
        private readonly IFixture _fixture;

        public BuyOrderServiceTests()
        {
            _fixture = new Fixture();

            _buyOrderRepositoryMock = new Mock<IBuyOrderRepository>();
            _buyOrderRepository = _buyOrderRepositoryMock.Object;

            _buyOrderService = new BuyOrdersService(_buyOrderRepository);
        }
    }
}
