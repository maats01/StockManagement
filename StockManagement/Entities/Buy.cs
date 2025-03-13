using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Buy
    {
        [Key]
        public int ID { get; set; }
        public float TotalValue { get; set; }
        [StringLength(25)]
        public string? Status { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int SupplierID { get; set; }
        [ForeignKey(nameof(SupplierID))]
        public Supplier? Supplier { get; set; }

        public virtual ICollection<BuyItem> BuyItems{ get; set; } = new List<BuyItem>();
    }
}
