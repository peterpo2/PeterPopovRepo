using Microsoft.AspNetCore.Mvc.Rendering;

namespace APTEKA_Software.Models.Dto
{
    public class DeliveryDto
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int QuantityDelivered { get; set; }
        public List<SelectListItem> Items { get; set; } = new List<SelectListItem>();
    }
}
