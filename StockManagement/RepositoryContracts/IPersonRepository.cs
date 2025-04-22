using Entities;
using System.Linq.Expressions;

namespace RepositoryContracts
{
    public interface IPersonRepository
    {
        Task<Person> AddPerson(Person person);
        Task<Person> UpdatePerson(Person person);
        Task<List<Person>> GetPersons();
        Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate);
        Task<List<Person>> GetCustomers();
        Task<List<Person>> GetSuppliers();
        Task<Person?> GetPersonByID(int id);
        Task<Person> RemovePerson(Person person);
    }
}
