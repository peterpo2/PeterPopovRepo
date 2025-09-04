namespace APTEKA_Software.Models.Dto
{
    public class ItemResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
