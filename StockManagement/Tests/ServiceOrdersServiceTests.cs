using AutoFixture;
using Moq;
using RepositoryContracts;
using ServiceContracts;
using Services;

namespace Tests
{
    public class ServiceOrdersServiceTests
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly Mock<IServiceOrderRepository> _serviceOrderRepositoryMock;
        private readonly IServiceOrdersService _serviceOrdersService;
        private readonly IFixture _fixture;

        public ServiceOrdersServiceTests()
        {
            _fixture = new Fixture();

            _serviceOrderRepositoryMock = new Mock<IServiceOrderRepository>();
            _serviceOrderRepository = _serviceOrderRepositoryMock.Object;

            _serviceOrdersService = new ServiceOrdersService(_serviceOrderRepository);
        }
    }
}
