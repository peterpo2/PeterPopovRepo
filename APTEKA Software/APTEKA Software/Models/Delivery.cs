namespace APTEKA_Software.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int QuantityDelivered { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Item Item { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
