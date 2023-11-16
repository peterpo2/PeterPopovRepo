using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Models.Dto;
using APTEKA_Software.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APTEKA_Software.Controllers.API
{
    [Route("api/items")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        private readonly IItemService itemService;
        private readonly IMapper mapper;

        public ItemApiController(IItemService itemService, IMapper mapper)
        {
            this.itemService = itemService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                var items = itemService.GetAllItems().Select(item => mapper.Map<ItemResponseDto>(item)).ToList();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            try
            {
                var item = itemService.GetItemById(id);
                return Ok(mapper.Map<ItemResponseDto>(item));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] ItemDto itemDto)
        {
            try
            {
                var createdItem = itemService.CreateItem(itemDto);
                return CreatedAtAction(nameof(GetItemById), new { id = createdItem.ItemId }, createdItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            try
            {
                var item = itemService.UpdateItem(id, updatedItem);
                return Ok(mapper.Map<ItemResponseDto>(item));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            try
            {
                var deletedItem = itemService.DeleteItem(id);
                return Ok(mapper.Map<ItemResponseDto>(deletedItem));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
