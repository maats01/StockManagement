using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class ServiceItem
    {
        [Key]
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor unitário deve ser um número entre 1 e 10000")]
        public float UnitValue { get; set; }
        [Range(1, 10000, ErrorMessage = "O custo deve ser um número entre 1 e 10000")]
        public int Quantity { get; set; }

        public int ServiceOrderID { get; set; }
        [ForeignKey(nameof(ServiceOrderID))]
        public ServiceOrder? ServiceOrder { get; set; }

        public int ItemID { get; set; }
        [ForeignKey(nameof(ItemID))]
        public Item? Item { get; set; }
    }
}
