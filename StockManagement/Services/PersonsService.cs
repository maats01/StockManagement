using Repositories;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IPersonRepository _personRepository;

        public PersonsService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<PersonDTO> AddPerson(PersonCreateDTO personCreateDTO)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO?> GetPersonByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDTO>> GetPersons()
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> RemovePerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> UpdatePerson(PersonUpdateDTO personUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
