using APTEKA_Software.Exeptions;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace APTEKA_Software.Controllers.API
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesApiController : ControllerBase
    {
        private readonly ISalesService salesService;

        public SalesApiController(ISalesService salesService)
        {
            this.salesService = salesService;
        }

        [HttpGet]
        public IActionResult GetAllSales()
        {
            var sales = salesService.GetAllSales();
            var saleDtos = sales.Select(sale => new SaleResponseDto
            {
                SaleId = sale.SaleId,
                UserId = sale.UserId,
                ItemId = sale.ItemId,
                SaleDate = sale.SaleDate,
                QuantitySold = sale.QuantitySold,
                TotalAmount = sale.TotalAmount
            }).ToList();

            return Ok(saleDtos);
        }

        [HttpPost]
        public IActionResult MakeSale([FromBody] SaleRequestDto saleRequest)
        {
            try
            {
                var saleResult = salesService.MakeSale(saleRequest.UserId, saleRequest.ItemId, saleRequest.QuantitySold);

                var remainingQuantity = salesService.GetRemainingQuantity(saleRequest.ItemId);

                return Ok(new SaleResultDto
                {
                    Success = saleResult.Success,
                    TotalSaleValue = saleResult.TotalSaleValue,
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
