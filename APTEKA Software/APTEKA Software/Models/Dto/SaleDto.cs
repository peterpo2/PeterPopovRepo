using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.Dto
{
    public class SaleDto
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }

        [Display(Name = "Дата на продажба")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "Продадено количество")]
        public int QuantitySold { get; set; }
        public int? RemainingQuantity { get; set; }

        [Display(Name = "Обща сума на артикули")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalPrice { get; set; }

        public List<SelectListItem> Items { get; set; } = new List<SelectListItem>();
    }
}
