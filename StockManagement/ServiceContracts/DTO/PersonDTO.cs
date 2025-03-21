using Entities;

namespace ServiceContracts.DTO
{
    public class PersonDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Document { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }

        public Person ToPerson()
        {
            return new Person()
            {
                ID = ID,
                Name = Name,
                Document = Document,
                Phone = Phone,
                Email = Email,
                Street = Street,
                Number = Number,
                Neighborhood = Neighborhood,
                State = State,
                City = City
            };
        }
    }

    public static class ExtensionMethod
    {
        public static PersonDTO ToPersonDTO(this Person person)
        {
            return new PersonDTO()
            {
                ID = person.ID,
                Name = person.Name,
                Document = person.Document,
                Phone = person.Phone,
                Email = person.Email,
                Street = person.Street,
                Number = person.Number,
                Neighborhood = person.Neighborhood,
                State = person.State,
                City = person.City
            };
        }
    }
}
