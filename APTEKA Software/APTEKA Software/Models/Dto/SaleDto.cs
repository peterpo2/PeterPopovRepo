using Microsoft.AspNetCore.Mvc.Rendering;

namespace APTEKA_Software.Models.Dto
{
    public class SaleDto
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalPrice { get; set; }
        public List<SelectListItem> Items { get; set; } = new List<SelectListItem>();
    }
}
