namespace APTEKA_Software.Models.Dto
{
    public class DeliveryResultDto
    {
        public bool Success { get; set; }
        public int QuantityDelivered { get; set; }
        public int RemainingQuantity { get; set; }
    }
}
