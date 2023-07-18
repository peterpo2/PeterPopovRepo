using AutoMapper;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Helpers;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers.API
{
    [Route("api/comments")]
    [ApiController]
    public class CommentApiController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly AuthManager authManager;

        public CommentApiController(ICommentService commentService, IMapper mapper, AuthManager authManager)
        {
            this.commentService = commentService;
            this.mapper = mapper;
            this.authManager = authManager;
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            try
            {
                var comment = commentService.GetById(id);
                return Ok(mapper.Map<CommentResponseDto>(comment));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("")]
        public IActionResult GetAllComments()
        {
            var comments = commentService.GetAll().Select(c => mapper.Map<CommentResponseDto>(c)).ToList();
            
            return Ok(comments);
        }


        [HttpPost("{postId}/comments")]
        public IActionResult CreateComment(int postId, [FromBody] CommentRequestDto commentDto, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var comment = mapper.Map<Comment>(commentDto);

                var createdComment = commentService.CreateComment(postId, commentDto, user);

                return StatusCode(StatusCodes.Status201Created, createdComment);
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


        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] CommentRequestDto commentDto, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var comment = mapper.Map<Comment>(commentDto);

                var updatedComment = commentService.UpdateComment(id, comment, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<CommentResponseDto>(updatedComment));
            }
            catch (UnauthorizedOperationException e)
            {
                return NotFound(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var comment = commentService.GetById(id);

                var deletedComment = commentService.DeleteComment(id, user);

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
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }
        [HttpPost("likes/{id}")]
        public IActionResult LikeComment(int id, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                
                var likedComment = commentService.LikeComment(id, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<CommentResponseDto>(likedComment));
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
        [HttpDelete("likes/{id}")]
        public IActionResult DisslikeComment(int id, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);

                var disslikedComment = commentService.DisslikeComment(id, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<CommentResponseDto>(disslikedComment));
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

