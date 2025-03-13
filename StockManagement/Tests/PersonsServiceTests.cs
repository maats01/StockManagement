using AutoFixture;
using Moq;
using RepositoryContracts;
using ServiceContracts;
using Services;
using FluentAssertions;

namespace Tests
{
    public class PersonsServiceTests
    {
        private readonly IPersonsService _personsService;
        private readonly IFixture _fixture;
        private readonly IPersonRepository _personRepository;
        private readonly Mock<IPersonRepository> _personRepositoryMock;

        public PersonsServiceTests()
        {
            _fixture = new Fixture();

            _personRepositoryMock = new Mock<IPersonRepository>();
            _personRepository = _personRepositoryMock.Object;

            _personsService = new PersonsService(_personRepository);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
