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
    [Route("api/replies")]
    public class ReplyApiController : ControllerBase
    {
        private readonly IReplyService replyService;
        private readonly IMapper mapper;
        private readonly AuthManager authManager;

        public ReplyApiController(IReplyService replyService, IMapper mapper, AuthManager authManager)
        {
            this.replyService = replyService;
            this.mapper = mapper;
            this.authManager = authManager;
        }

        [HttpGet("{id}")]
        public IActionResult GetReply(int id)
        {
            try
            {
                var reply = replyService.GetReplyById(id);
                return Ok(mapper.Map<ReplyResponseDto>(reply));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("comments/{commentId}/replies")]
        public IActionResult GetAllRepliesFromComment(int commentId)
        {
            try
            {
                var replies = replyService.GetRepliesByComment(commentId);
                var response = replies.Select(r => mapper.Map<ReplyResponseDto>(r)).ToList();

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpPost("")]
        public IActionResult CreateReply(int commentId, [FromBody] ReplyRequestDto replyDto, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var createdReply = replyService.CreateReply(commentId, replyDto, user);

                return StatusCode(StatusCodes.Status201Created, mapper.Map<ReplyResponseDto>(createdReply));
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReply(int id, [FromBody] ReplyRequestDto replyDto, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var reply = mapper.Map<Reply>(replyDto);

                var updatedReply = replyService.UpdateReply(id, reply, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<ReplyResponseDto>(updatedReply));
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReply(int id, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var reply = replyService.GetReplyById(id);

                var deletedReply = replyService.DeleteReply(id, user);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpPost("{replyId}/likes")]
        public IActionResult LikeReply(int replyId, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var likedReply = replyService.LikeReply(replyId, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<ReplyResponseDto>(likedReply));
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }

        [HttpDelete("{replyId}/likes")]
        public IActionResult DislikeReply(int replyId, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var dislikedReply = replyService.DislikeReply(replyId, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<LikeResponseDto>(dislikedReply));
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }

    }
}

