using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int QuantityDelivered { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
    }

}
