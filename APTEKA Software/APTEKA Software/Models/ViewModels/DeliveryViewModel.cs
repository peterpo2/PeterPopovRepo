using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class DeliveryViewModel
    {
        public int DeliveryId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please select an item.")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please enter a quantity.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int QuantityDelivered { get; set; }
        public string ItemName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public List<SelectListItem> AvailableItems { get; set; }
        public decimal TotalAmount { get; set; }
        public User User { get; set; }
        public Item Item { get; set; }
    }
}
