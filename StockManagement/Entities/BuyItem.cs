using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class BuyItem
    {
        [Key]
        public int ID { get; set; }
        public float UnitValue { get; set; }
        public int Quantity { get; set; }

        public int BuyID { get; set; }
        [ForeignKey(nameof(BuyID))]
        public Buy? Buy { get; set; }

        public int ItemID { get; set; }
        [ForeignKey(nameof(ItemID))]
        public Item? Item { get; set; }
    }
}
