using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage = "Item name is empty.")]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "Item name must be between 3 and 32 characters.")]
        public string Name { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
