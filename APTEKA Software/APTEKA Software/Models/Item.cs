using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
