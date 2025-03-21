using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Stock
    {
        [Key, ForeignKey(nameof(Item))]
        public int ItemID { get; set; }
        [Range(1, 10000, ErrorMessage = "A quantidade deve ser um número entre 1 e 10000")]
        public int Quantity { get; set; }
        [Range(1, 10000, ErrorMessage = "O custo deve ser um número entre 1 e 10000")]
        public float Cost { get; set; }
        public Item? Item { get; set; }
    }
}
