using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class ServiceItem
    {
        [Key]
        public int ID { get; set; }
        public float UnitValue { get; set; }
        public int Quantity { get; set; }

        public int ServiceOrderID { get; set; }
        [ForeignKey(nameof(ServiceOrderID))]
        public ServiceOrder? ServiceOrder { get; set; }

        public int ItemID { get; set; }
        [ForeignKey(nameof(ItemID))]
        public Item? Item { get; set; }
    }
}
