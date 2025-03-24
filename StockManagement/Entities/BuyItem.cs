using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Entity that represents a relationship between BuyOrder and Item
    /// </summary>
    public class BuyItem
    {
        [Key]
        public int ID { get; set; }
        [Range(0.01, 10000, ErrorMessage = "O valor unitário deve ser um número entre 0.01 e 10000")]
        public float UnitValue { get; set; }
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser um número entre 1 e 10000")]
        public int Quantity { get; set; }

        public int BuyID { get; set; }
        [ForeignKey(nameof(BuyID))]
        public BuyOrder? BuyOrder { get; set; }

        public int ItemID { get; set; }
        [ForeignKey(nameof(ItemID))]
        public Item? Item { get; set; }
    }
}
