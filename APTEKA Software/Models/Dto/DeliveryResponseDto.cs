namespace APTEKA_Software.Models.Dto
{
    public class DeliveryResponseDto
    {
        public int DeliveryId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int QuantityDelivered { get; set; }
    }
}
