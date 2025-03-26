using AutoFixture;
using Moq;
using RepositoryContracts;
using ServiceContracts;
using Services;

namespace Tests
{
    public class VehiclesServiceTests
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly Mock<IVehicleRepository> _vehicleRepositoryMock;
        private readonly IVehiclesService _vehiclesService;
        private readonly IFixture _fixture;

        public VehiclesServiceTests()
        {
            _fixture = new Fixture();

            _vehicleRepositoryMock = new Mock<IVehicleRepository>();
            _vehicleRepository = _vehicleRepositoryMock.Object;

            _vehiclesService = new VehiclesService(_vehicleRepository);
        }
    }
}
