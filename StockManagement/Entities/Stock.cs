using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Stock
    {
        [Key, ForeignKey(nameof(Item))]
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public float Cost { get; set; }
        public Item? Item { get; set; }
    }
}
