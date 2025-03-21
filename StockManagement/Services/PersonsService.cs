using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IPersonRepository _personRepository;

        public PersonsService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> AddPerson(PersonCreateDTO? personCreateDTO)
        {
            if (personCreateDTO == null)
                throw new ArgumentNullException(nameof(personCreateDTO));

            ValidationHelper.ModelValidation(personCreateDTO);

            Person person = await _personRepository.AddPerson(personCreateDTO.ToPerson());

            return person.ToPersonDTO();
        }

        public async Task<PersonDTO?> GetPersonByID(int id)
        {
            Person? person = await _personRepository.GetPersonByID(id);

            if (person == null)
                return null;

            return person.ToPersonDTO();
        }

        public async Task<List<PersonDTO>> GetPersons()
        {
            List<PersonDTO> persons = (await _personRepository.GetPersons())
                .Select(p => p.ToPersonDTO())
                .ToList();

            return persons;
        }

        public async Task<List<PersonDTO>> GetCustomers()
        {
            List<PersonDTO> customers = (await _personRepository.GetCustomers())
                .Select(p => p.ToPersonDTO())
                .ToList();

            return customers;
        }

        public async Task<List<PersonDTO>> GetSuppliers()
        {
            List<PersonDTO> suppliers = (await _personRepository.GetSuppliers())
                .Select(p => p.ToPersonDTO())
                .ToList();

            return suppliers;
        }

        public async Task<bool> RemovePerson(int id)
        {
            Person? person = await _personRepository.GetPersonByID(id);

            if (person == null)
                return false;

            await _personRepository.RemovePerson(person);

            return true;
        }

        public async Task<PersonDTO> UpdatePerson(PersonUpdateDTO? personUpdateDTO)
        {
            if (personUpdateDTO == null)
                throw new ArgumentNullException(nameof(personUpdateDTO));

            ValidationHelper.ModelValidation(personUpdateDTO);

            Person person = await _personRepository.UpdatePerson(personUpdateDTO.ToPerson());

            return person.ToPersonDTO();
        }
    }
}
