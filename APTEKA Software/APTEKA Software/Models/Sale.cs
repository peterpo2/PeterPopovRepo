using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APTEKA_Software.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public DateTime SaleDate { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
    }
}
