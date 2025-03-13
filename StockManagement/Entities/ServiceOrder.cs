using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class ServiceOrder
    {
        [Key]
        public int ID { get; set; }
        public float TotalProductValue { get; set; }
        public float TotalLabor { get; set; }
        [StringLength(25)]
        public string? Status { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public Customer? Customer { get; set; }

        public virtual ICollection<ServiceItem> ItemsService { get; set; } = new List<ServiceItem>();
    }
}
