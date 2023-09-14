using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public int QuantityDelivered { get; set; }

        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
    }

}
