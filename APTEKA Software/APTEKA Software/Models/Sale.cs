using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APTEKA_Software.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public int QuantitySold { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
    }
}
