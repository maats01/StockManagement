using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Entity that represents a buy order
    /// </summary>
    public class BuyOrder
    {
        [Key]
        public int ID { get; set; }
        [Range(1, 10000, ErrorMessage = "O valor total deve ser um número entre 1 e 100000")]
        public float TotalValue { get; set; }
        [StringLength(25)]
        public string? Status { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int SupplierID { get; set; }
        [ForeignKey(nameof(SupplierID))]
        public Person? Supplier { get; set; }

        public virtual ICollection<BuyItem> BuyItems{ get; set; } = new List<BuyItem>();
    }
}
