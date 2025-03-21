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
        private readonly IPersonRepository _personsRepository;
        private readonly Mock<IPersonRepository> _personsRepositoryMock;

        public PersonsServiceTests()
        {
            _fixture = new Fixture();

            _personsRepositoryMock = new Mock<IPersonRepository>();
            _personsRepository = _personsRepositoryMock.Object;

            _personsService = new PersonsService(_personsRepository);
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

            Person person = personCreateDTO.ToPerson();
            person.ID = 1;
            PersonDTO expected = person.ToPersonDTO();

            _personsRepositoryMock
                .Setup(temp => temp.AddPerson(It.IsAny<Person>()))
                .ReturnsAsync(person);

            PersonDTO actual = await _personsService.AddPerson(personCreateDTO);

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetPersons

        [Fact]
        public async Task GetPersons_EmptyListByDefault()
        {
            List<Person> persons = new();

            _personsRepositoryMock
                .Setup(temp => temp.GetPersons())
                .ReturnsAsync(persons);

            List<PersonDTO> response = await _personsService.GetPersons();

            response.Should().BeEmpty();
        }

        [Fact]
        public async Task GetPersons_NotEmpty()
        {
            List<Person> persons = new List<Person>
            {
                BuildExamplePerson(), BuildExamplePerson(), BuildExamplePerson()
            };
            List<PersonDTO> expected = persons.Select(p => p.ToPersonDTO()).ToList();

            _personsRepositoryMock
                .Setup(temp => temp.GetPersons())
                .ReturnsAsync(persons);

            List<PersonDTO> actual = await _personsService.GetPersons();

            actual.Should().NotBeEmpty();
            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region GetCustomers

        [Fact]
        public async Task GetCustomers_ToBeSuccessful()
        {
            Person person1 = _fixture.Build<Person>()
                .With(p => p.IsCustomer, true)
                .Create();

            Person person2 = _fixture.Build<Person>()
                .With(p => p.IsCustomer, true)
                .Create();

            List<Person> expectedPersons = new List<Person>
            {
                person1, person2
            };

            List<PersonDTO> expectedPersonsDTO = expectedPersons.Select(p => p.ToPersonDTO()).ToList();

            _personsRepositoryMock
                .Setup(temp => temp.GetCustomers())
                .ReturnsAsync(expectedPersons);

            List<PersonDTO> response = await _personsService.GetCustomers();

            response.Should().NotBeEmpty();
            response.Should().BeEquivalentTo(expectedPersonsDTO);
        }

        #endregion

        #region GetSuppliers

        [Fact]
        public async Task GetSuppliers_ToBeSuccessful()
        {
            Person person1 = _fixture.Build<Person>()
                .With(p => p.IsCustomer, false)
                .Create();

            Person person2 = _fixture.Build<Person>()
                .With(p => p.IsCustomer, false)
                .Create();

            List<Person> expectedPersons = new List<Person>
            {
                person1, person2
            };
            List<PersonDTO> expectedPersonsDTO = expectedPersons.Select(p => p.ToPersonDTO()).ToList();

            _personsRepositoryMock
                .Setup(temp => temp.GetSuppliers())
                .ReturnsAsync(expectedPersons);

            List<PersonDTO> response = await _personsService.GetSuppliers();

            response.Should().NotBeEmpty();
            response.Should().BeEquivalentTo(expectedPersonsDTO);
        }

        #endregion

        #region GetPersonByID

        [Fact]

        public async Task GetPersonByID_InvalidID_ToBeNull()
        {
            _personsRepositoryMock
                .Setup(temp => temp.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(null as Person);

            PersonDTO? response = await _personsService.GetPersonByID(0);

            response.Should().BeNull();
        }

        [Fact]
        public async Task GetPersonByID_ValidID_ToBeSuccessful()
        {
            Person person = BuildExamplePerson();
            PersonDTO expected = person.ToPersonDTO();

            _personsRepositoryMock
                .Setup(t => t.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(person);

            PersonDTO? response = await _personsService.GetPersonByID(expected.ID);

            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region UpdatePerson

        [Fact]
        public async Task UpdatePerson_NullUpdateDTO_ToThrowArgumentNullException()
        {
            PersonUpdateDTO? personUpdateDTO = null;

            Func<Task> action = async () =>
            {
                await _personsService.UpdatePerson(personUpdateDTO);
            };

            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task UpdatePerson_ValidUpdateDTO_ToBeSuccessful()
        {
            PersonUpdateDTO? personUpdateDTO = _fixture
                .Build<PersonUpdateDTO>()
                .With(p => p.Email, "example@email.com")
                .Create();

            Person person = personUpdateDTO.ToPerson();
            PersonDTO expected = person.ToPersonDTO();

            _personsRepositoryMock
                .Setup(temp => temp.UpdatePerson(It.IsAny<Person>()))
                .ReturnsAsync(person);

            PersonDTO actual = await _personsService.UpdatePerson(personUpdateDTO);

            actual.Should().BeEquivalentTo(expected);
        }

        #endregion

        #region RemovePerson

        [Fact]
        public async Task RemovePerson_InvalidID_ToBeFalse()
        {
            bool isRemoved = await _personsService.RemovePerson(55);

            _personsRepositoryMock
                .Setup(t => t.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(null as Person);

            isRemoved.Should().BeFalse();
        }

        [Fact]
        public async Task RemovePerson_ValidID_ToBeTrue()
        {
            Person person = BuildExamplePerson();

            _personsRepositoryMock
                .Setup(t => t.GetPersonByID(It.IsAny<int>()))
                .ReturnsAsync(person);

            bool isRemoved = await _personsService.RemovePerson(person.ID);

            isRemoved.Should().BeTrue();
        }

        #endregion
    }
}
