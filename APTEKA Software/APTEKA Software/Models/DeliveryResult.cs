namespace APTEKA_Software.Models
{
    public class DeliveryResult
    {
        public bool Success { get; set; }
        public int QuantityDelivered { get; set; }
        public int NewAvailableQuantity { get; set; }
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int RemainingQuantity { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Item Item { get; set; }
        public User User { get; set; }
    }
}
