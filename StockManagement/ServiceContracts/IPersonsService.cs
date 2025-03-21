using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IPersonsService
    {
        Task<PersonDTO> AddPerson(PersonCreateDTO? personCreateDTO);
        Task<List<PersonDTO>> GetPersons();
        Task<PersonDTO?> GetPersonByID(int id);
        Task<PersonDTO> UpdatePerson(PersonUpdateDTO? personUpdateDTO);
        Task<bool> RemovePerson(int id);
    }
}
