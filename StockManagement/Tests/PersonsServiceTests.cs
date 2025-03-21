using AutoFixture;
using Moq;
using RepositoryContracts;
using ServiceContracts;
using Services;
using FluentAssertions;
using ServiceContracts.DTO;
using Entities;

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

        public Person BuildExamplePerson()
        {
            return _fixture.Build<Person>().With(p => p.Email, "example@email.com").Create();
        }

        #region AddPerson

        [Fact]
        public async Task AddPerson_NullCreateDTO_ToThrowArgumentNullException()
        {
            PersonCreateDTO? personCreateDTO = null;

            Func<Task> action = async () =>
            {
                await _personsService.AddPerson(personCreateDTO);
            };

            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AddPerson_ValidCreateDTO_ToBeSuccessful()
        {
            PersonCreateDTO personCreateDTO = _fixture.Build<PersonCreateDTO>()
                .With(p => p.Email, "example@gmail.com")
                .Create();

            Person expected = personCreateDTO.ToPerson();
            expected.ID = 1;

            _personRepositoryMock
                .Setup(temp => temp.AddPerson(It.IsAny<Person>()))
                .ReturnsAsync(expected);

            PersonDTO personDTO = await _personsService.AddPerson(personCreateDTO);
            Person actual = personDTO.ToPerson();

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetPersons

        [Fact]
        public async Task GetPersons_EmptyListByDefault()
        {
            List<Person> persons = new();

            _personRepositoryMock
                .Setup(temp => temp.GetPersons())
                .ReturnsAsync(persons);

            List<PersonDTO> response = await _personsService.GetPersons();

            response.Should().BeEmpty();
        }

        [Fact]
        public async Task GetPersons_NotEmpty()
        {
            List<Person> expectedPersons = new List<Person> 
            { 
                BuildExamplePerson(), BuildExamplePerson(), BuildExamplePerson()
            };

            _personRepositoryMock
                .Setup(temp => temp.GetPersons())
                .ReturnsAsync(expectedPersons);

            List<PersonDTO> response = await _personsService.GetPersons();

            response.Should().NotBeEmpty();
            response.Should().BeEquivalentTo(response);
        }

        #endregion

        #region GetPersonByID

        [Fact]

        public async Task GetPersonByID_InvalidID()
        {
            _personRepositoryMock
                .Setup(temp => temp.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(null as Person);

            PersonDTO? response = await _personsService.GetPersonByID(0);

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetPersonByID_ValidID()
        {
            Person expected = BuildExamplePerson();

            _personRepositoryMock
                .Setup(t => t.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(expected);

            PersonDTO? response = await _personsService.GetPersonByID(expected.ID);

            response.Should().NotBeNull();
            response.ID.Should().Be(expected.ID);
        }

        #endregion

        #region UpdatePerson

        [Fact]
        public async Task UpdatePerson_NullUpdateDTO_ShouldThrowArgumentNullException()
        {
            PersonUpdateDTO? personUpdateDTO = null;

            Func<Task> action = async () => 
            {
                await _personsService.UpdatePerson(personUpdateDTO);
            };

            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task UpdatePerson_ValidValues()
        {
            PersonUpdateDTO? personUpdateDTO = _fixture
                .Build<PersonUpdateDTO>()
                .With(p => p.Email, "example@email.com")
                .Create();

            Person expected = personUpdateDTO.ToPerson();
            _personRepositoryMock
                .Setup(temp => temp.UpdatePerson(It.IsAny<Person>()))
                .ReturnsAsync(expected);

            PersonDTO response = await _personsService.UpdatePerson(personUpdateDTO);
            Person actual = response.ToPerson();

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region RemovePerson
        
        [Fact]
        public async Task RemovePerson_InvalidID()
        {
            bool isRemoved = await _personsService.RemovePerson(55);

            _personRepositoryMock
                .Setup(t => t.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(null as Person);

            isRemoved.Should().BeFalse();
        }

        [Fact]
        public async Task RemovePerson_ValidID()
        {
            Person person = BuildExamplePerson();

            _personRepositoryMock
                .Setup(t => t.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(person);

            bool isRemoved = await _personsService.RemovePerson(person.ID);

            isRemoved.Should().BeTrue();
        }

        #endregion
    }
}
