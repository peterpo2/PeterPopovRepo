namespace APTEKA_Software.Models.ViewModels
{
    public class DeliveryItemViewModel
    {
        public int DeliveryId { get; set; }
        public int ItemId { get; set; }
        public User User { get; set; }
        public string UserName { get; set; }
        public string ItemName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int QuantityDelivered { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
