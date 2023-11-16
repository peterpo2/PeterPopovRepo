using System.ComponentModel.DataAnnotations;

namespace APTEKA_Software.Models.Dto
{
    public class DeliveryRequestDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int QuantityDelivered { get; set; }
    }
}
