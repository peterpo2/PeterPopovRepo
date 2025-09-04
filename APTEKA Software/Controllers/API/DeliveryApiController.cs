using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APTEKA_Software.Controllers.API
{
    [Route("api/deliveries")]
    [ApiController]
    public class DeliveryApiController : ControllerBase
    {
        private readonly IDeliveryService deliveryService;
        private readonly IItemService itemService;

        public DeliveryApiController(IDeliveryService deliveryService, IItemService itemService)
        {
            this.deliveryService = deliveryService;
            this.itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAllDeliveries()
        {
            var deliveries = deliveryService.GetAllDeliveries().Select(d => new DeliveryResponseDto
            {
                DeliveryId = d.DeliveryId,
                UserId = d.UserId,
                ItemId = d.ItemId,
                DeliveryDate = d.DeliveryDate,
                QuantityDelivered = d.QuantityDelivered
            }).ToList();

            return Ok(deliveries);
        }

        [HttpPost]
        public IActionResult MakeDelivery([FromBody] DeliveryRequestDto deliveryRequest)
        {
            try
            {
                var item = itemService.GetItemById(deliveryRequest.ItemId);

                if (item == null || item.AvailableQuantity < deliveryRequest.QuantityDelivered)
                {
                    return BadRequest("Артикулът не е наличен или няма достатъчно количество за доставка.");
                }

                var deliveryResult = deliveryService.MakeDelivery(deliveryRequest.UserId, deliveryRequest.ItemId, deliveryRequest.QuantityDelivered);

                var remainingQuantity = deliveryService.GetRemainingQuantity(deliveryResult.ItemId);

                return Ok(new DeliveryResultDto
                {
                    Success = deliveryResult.Success,
                    QuantityDelivered = deliveryResult.QuantityDelivered,
                    RemainingQuantity = remainingQuantity
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
