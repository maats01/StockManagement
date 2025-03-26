using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Entity representing a vehicle
    /// </summary>
    public class Vehicle
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30)]
        public string? Type { get; set; }
        [StringLength(7)]
        public string? Plate { get; set; }

        public int OwnerID { get; set; }
        [ForeignKey(nameof(OwnerID))]
        public Person? Owner { get; set; }

        public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
    }
}
