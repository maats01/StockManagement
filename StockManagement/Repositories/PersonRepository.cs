using Entities;
using RepositoryContracts;

namespace Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<Person> AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetPersonByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetPersons()
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
