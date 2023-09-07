namespace APTEKA_Software.Models.Dto
{
    public class SaleResultDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }
        public bool Success { get; set; }
        public decimal TotalSaleValue { get; set; }
    }
}
