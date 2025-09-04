using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class DeliveryViewModel
    {
        // public int DeliveryId { get; set; }
        // public int UserViewModelId { get; set; }
        // public int UserId { get; set; }
        // public string UserName { get; set; }
        // public int ItemId { get; set; }
        // public string ItemName { get; set; }
        // public DateTime DeliveryDate { get; set; }
        // public int QuantityDelivered { get; set; }
        // public decimal DeliverySum { get; set; }
        // //public decimal TotalAmount { get; set; }
        public int DeliveryId { get; set; }
        public int UserViewModelId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        [Required]
        public List<int> SelectedItemIds { get; set; } = new List<int>(); // List to hold selected item IDs

        public List<ItemViewModel> Items { get; set; } = new List<ItemViewModel>(); // List of available items
        public string ItemName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int QuantityDelivered { get; set; }
        public decimal DeliverySum { get; set; }
    }
}

