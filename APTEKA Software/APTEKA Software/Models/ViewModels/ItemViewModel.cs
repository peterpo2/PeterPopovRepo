using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class ItemViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "Име на потребител")]

        public int ItemId { get; set; }

        [Display(Name = "Име на артикул")]
        public string ItemName { get; set; }


        [Display(Name = "Налично количество")]
        public int AvailableQuantity { get; set; }

        [Display(Name = "Продадено количество")]
        public int QuantitySold { get; set; }

        [Display(Name = "Цена на продажба")]
        public decimal SalePrice { get; set; }
    }
}
