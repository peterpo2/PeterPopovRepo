using System.ComponentModel.DataAnnotations.Schema;

namespace APTEKA_Software.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
