using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Налично количество")]
        public int AvailableQuantity { get; set; }

        [Display(Name = "Цена на продажба")]
        public decimal SalePrice { get; set; }
    }
}
