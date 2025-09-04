namespace APTEKA_Software.Models.Dto
{
    public class SaleResponseDto
    {
        public int SaleId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public DateTime SaleDate { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
