using AutoMapper;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Helpers;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers.API
{
    [ApiController]
    [Route("api/tags")]
    public class TagApiController : ControllerBase
    {
        private readonly ITagService tagService;
        private readonly IMapper mapper;
        private readonly AuthManager authManager;

        public TagApiController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpPost("")]
        public IActionResult CreateTag([FromBody] TagDto tagDto)
        {
            var createdTag = tagService.CreateTag(tagDto);
            if (createdTag != null)
            {
                return StatusCode(StatusCodes.Status201Created, createdTag);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create tag.");
            }
        }

        [HttpGet("{tagId}")]
        public IActionResult GetTagById(int tagId)
        {
            var tag = tagService.GetTagById(tagId);
            if (tag != null)
            {
                return Ok(tag);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("")]
        public IActionResult GetAllTags()
        {
            var tags = tagService.GetAllTags();
            return Ok(tags);
        }

    }
}
