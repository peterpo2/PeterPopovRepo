using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.Dto
{
    public class ItemDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 32 characters.")]
        public string ItemName { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal SalePrice { get; set; }
    }
}
