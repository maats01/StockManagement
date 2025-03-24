using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Interface representing business logic for manipulating Person entity
    /// </summary>
    public interface IPersonsService
    {
        /// <summary>
        /// Inserts a new Person in the database
        /// </summary>
        /// <param name="personCreateDTO">Person to add</param>
        /// <returns>The newly added person as a PersonDTO</returns>
        Task<PersonDTO> AddPerson(PersonCreateDTO personCreateDTO);
        /// <summary>
        /// Returns every person in the database
        /// </summary>
        /// <returns>List of PersonDTO objects</returns>
        Task<List<PersonDTO>> GetPersons();
        /// <summary>
        /// Returns only the persons that are customers
        /// </summary>
        /// <returns>List of PersonDTO objects</returns>
        Task<List<PersonDTO>> GetCustomers();
        /// <summary>
        /// Returns only the persons that are suppliers
        /// </summary>
        /// <returns>List of PersonDTO objects</returns>
        Task<List<PersonDTO>> GetSuppliers();
        /// <summary>
        /// Returns a person based on the given ID; returns null if a person isn't found
        /// </summary>
        /// <param name="id">ID to search</param>
        /// <returns>PersonDTO object or null</returns>
        Task<PersonDTO?> GetPersonByID(int id);
        /// <summary>
        /// Updates a Person in the database
        /// </summary>
        /// <param name="personUpdateDTO">Person to update</param>
        /// <returns>PersonDTO object with updated data</returns>
        Task<PersonDTO> UpdatePerson(PersonUpdateDTO personUpdateDTO);
        /// <summary>
        /// Removes a person based on given ID
        /// </summary>
        /// <param name="id">ID to search</param>
        /// <returns>True if the person was removed correctly; if not, 
        /// returns False</returns>
        Task<bool> RemovePerson(int id);
    }
}
