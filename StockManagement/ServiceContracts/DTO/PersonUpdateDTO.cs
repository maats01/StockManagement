using Entities;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class PersonUpdateDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "O Nome não pode ficar em branco")]
        public string? Name { get; set; }
        public string? Document { get; set; }
        [Required(ErrorMessage = "O Telefone não pode ficar em branco")]
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public bool IsCustomer { get; set; }

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
                City = City,
                IsCustomer = IsCustomer
            };
        }
    }
}
