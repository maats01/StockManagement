using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// Entity that represents a person
    /// </summary>
    public class Person
    {
        [Key]
        public int ID { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "O Nome não pode ficar em branco")]
        public string? Name { get; set; }
        [StringLength(14)]
        public string? Document { get; set; }
        [StringLength(11)]
        [Required(ErrorMessage = "O Telefone não pode ficar em branco")]
        public string? Phone { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? Street { get; set; }
        [StringLength(10)]
        public string? Number { get; set; }
        [StringLength(50)]
        public string? Neighborhood { get; set; }
        [StringLength(50)]
        public string? State { get; set; }
        [StringLength(50)]
        public string? City { get; set; }
        public bool IsCustomer { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
