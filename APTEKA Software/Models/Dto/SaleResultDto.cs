namespace APTEKA_Software.Models.Dto
{
    public class SaleResultDto
    {
        public bool Success { get; set; }
        public decimal TotalSaleValue { get; set; }
        public int RemainingQuantity { get; set; }
    }
}
