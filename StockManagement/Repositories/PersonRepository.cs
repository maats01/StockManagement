using Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Person> AddPerson(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();

            return person;
        }

        public async Task<Person> RemovePerson(Person person)
        {
            _db.Persons.Remove(person);
            await _db.SaveChangesAsync();

            return person;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _db.Persons.OfType<Customer>().ToListAsync();
        }

        public async Task<Person?> GetPersonByID(int id)
        {
            return await _db.Persons.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<List<Person>> GetPersons()
        {
            return await _db.Persons.ToListAsync();
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            return await _db.Persons.OfType<Supplier>().ToListAsync();
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            _db.Persons.Update(person);
            await _db.SaveChangesAsync();

            return person;
        }
    }
}
