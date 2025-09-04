using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class SaleViewModel
    {
        public int SaleId { get; set; }

        public int UserId { get; set; }
        public int UserViewModelId { get; set; }
        public string UserName { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }

        [Display(Name = "Дата на продажба")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "Продадено количество")]
        public int QuantitySold { get; set; }

        [Display(Name = "Обща сума на артикули")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalAmount { get; set; }

        public UserViewModel User { get; set; }
        public ItemViewModel Item { get; set; }

        // New property to hold the list of items
        public List<ItemViewModel> Items { get; set; }
    }
}
