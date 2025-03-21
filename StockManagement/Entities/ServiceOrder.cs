using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Entity representing a service order
    /// </summary>
    public class ServiceOrder
    {
        [Key]
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor total deve ser um número entre 1 e 100000")]
        public float TotalProductValue { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor de mão de obra deve ser um número entre 1 e 10000")]
        public float TotalLabor { get; set; }
        [StringLength(25)]
        public string? Status { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public Person? Customer { get; set; }

        public virtual ICollection<ServiceItem> ItemsService { get; set; } = new List<ServiceItem>();
    }
}
