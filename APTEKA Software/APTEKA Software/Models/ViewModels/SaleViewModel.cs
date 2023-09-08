using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class SaleViewModel
    {
        [Required(ErrorMessage = "Изберете артикул")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Въведете количество")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество трябва да е положително число")]
        public int Quantity { get; set; }

        public decimal SalePrice { get; set; }
        public decimal TotalSaleValue { get; set; }
        public List<SaleItemViewModel> SaleItems { get; set; }

        public List<SelectListItem> AvailableItems { get; set; }
    }
}
