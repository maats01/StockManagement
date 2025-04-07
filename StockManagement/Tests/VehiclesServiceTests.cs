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

        public Vehicle BuildExampleVehicle()
        {
            return _fixture.Build<Vehicle>()
                .With(v => v.Owner, null as Person)
                .With(v => v.ServiceOrders, null as ICollection<ServiceOrder>)
                .Create();
        }

        #region AddVehicle

        [Fact]
        public async Task AddVehicle_ValidCreateDTO_ToBeSuccessful()
        {
            VehicleCreateDTO vehicleCreateDTO = _fixture.Create<VehicleCreateDTO>();
            Vehicle vehicle = vehicleCreateDTO.ToVehicle();
            VehicleDTO expected = vehicle.ToVehicleDTO();

            _vehicleRepositoryMock
                .Setup(t => t.AddVehicle(It.IsAny<Vehicle>()))
                .ReturnsAsync(vehicle);

            VehicleDTO actual = await _vehiclesService.AddVehicle(vehicleCreateDTO);

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetVehicleByID

        [Fact]
        public async Task GetVehicleByID_InvalidID_ToBeNull()
        {
            VehicleDTO? response = await _vehiclesService.GetVehicleByID(55);

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetVehicleByID_ValidID_ToBeSuccessful()
        {
            Vehicle vehicle = _fixture.Create<Vehicle>();
            VehicleDTO expected = vehicle.ToVehicleDTO();

            _vehicleRepositoryMock
                .Setup(t => t.GetVehicleByID(It.IsAny<int>()))
                .ReturnsAsync(vehicle);

            VehicleDTO? actual = await _vehiclesService.GetVehicleByID(vehicle.ID);

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetVehicleByPlate

        [Fact]
        public async Task GetVehicleByPlate_InvalidPlate_ToBeNull()
        {
            VehicleDTO? response = await _vehiclesService.GetVehicleByPlate("SANM123");

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetVehicleByPlate_ValidPlate_ToBeSuccessful()
        {
            Vehicle vehicle = BuildExampleVehicle();
            VehicleDTO expected = vehicle.ToVehicleDTO();

            _vehicleRepositoryMock
                .Setup(t => t.GetVehicleByPlate(It.IsAny<string>()))
                .ReturnsAsync(vehicle);

            VehicleDTO? actual = await _vehiclesService.GetVehicleByPlate(vehicle.Plate!);

            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetVehicles

        [Fact]
        public async Task GetVehicles_EmptyListByDefault()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            _vehicleRepositoryMock
                .Setup(t => t.GetVehicles())
                .ReturnsAsync(vehicles);

            List<VehicleDTO> response = await _vehiclesService.GetVehicles();

            response.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetVehicles_NotEmptyList()
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                BuildExampleVehicle(), BuildExampleVehicle(), BuildExampleVehicle()
            };
            List<VehicleDTO> expected = vehicles.Select(t => t.ToVehicleDTO()).ToList();

            _vehicleRepositoryMock
                .Setup(t => t.GetVehicles())
                .ReturnsAsync(vehicles);

            List<VehicleDTO> actual = await _vehiclesService.GetVehicles();

            actual.Should().NotBeEmpty();
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region UpdateVehicle

        [Fact]
        public async Task UpdateVehicle_ValidUpdateDTO_ToBeSuccessful()
        {
            VehicleUpdateDTO vehicleUpdateDTO = _fixture.Build<VehicleUpdateDTO>()
                .With(v => v.Owner, null as PersonDTO)
                .Create();
            Vehicle vehicle = vehicleUpdateDTO.ToVehicle();
            VehicleDTO expected = vehicle.ToVehicleDTO();

            _vehicleRepositoryMock
                .Setup(t => t.UpdateVehicle(It.IsAny<Vehicle>()))
                .ReturnsAsync(vehicle);

            VehicleDTO actual = await _vehiclesService.UpdateVehicle(vehicleUpdateDTO);

            actual.Should().BeEquivalentTo(vehicleUpdateDTO);
        }

        #endregion

        #region RemoveVehicle

        [Fact]
        public async Task RemoveVehicle_InvalidID_ToBeFalse()
        {
            _vehicleRepositoryMock
                .Setup(t => t.GetVehicleByID(It.IsAny<int>()))
                .ReturnsAsync(null as Vehicle);

            bool isRemoved = await _vehiclesService.RemoveVehicle(55);

            isRemoved.Should().BeFalse();
        }

        [Fact]
        public async Task RemoveVehicle_ValidID_ToBeTrue()
        {
            Vehicle vehicle = BuildExampleVehicle();

            _vehicleRepositoryMock
                .Setup(t => t.GetVehicleByID(It.IsAny<int>()))
                .ReturnsAsync(vehicle);
            _vehicleRepositoryMock
                .Setup(t => t.RemoveVehicle(It.IsAny<Vehicle>()))
                .ReturnsAsync(vehicle);

            bool isRemoved = await _vehiclesService.RemoveVehicle(vehicle.ID);

            isRemoved.Should().BeTrue();
        }

        #endregion

    }
}
