using AutoMapper;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Helpers;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Services;
using Gaming_Forum.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers.API
{
    [Route("api/posts")]
    [ApiController]
    public class PostApiController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly IMapper mapper;
        private readonly AuthManager authManager;

        public PostApiController(IPostService postService, ICommentService commentService, IMapper mapper, AuthManager authManager)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.mapper = mapper;
            this.authManager = authManager;
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            try
            {
                var post = postService.GetPostById(id);
                return Ok(mapper.Map<PostDto>(post));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("")]
        public IActionResult GetAllPosts()
        {
            var posts = postService.GetAllPosts();
            return Ok(posts.Select(p => mapper.Map<PostDto>(p)));
        }

        [HttpPost("")]
        public IActionResult CreatePost([FromBody] PostDto postDto, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var post = mapper.Map<Post>(postDto);

                var createdPost = postService.CreatePost(postDto, user);

                return StatusCode(StatusCodes.Status201Created, createdPost);
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
        public IActionResult UpdatePost(int id, [FromBody] PostDto postDto, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var post = mapper.Map<Post>(postDto);

                var updatedPost = postService.UpdatePost(id, post, user);

                return StatusCode(StatusCodes.Status200OK, updatedPost);
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

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var deletedPost = postService.DeletePost(id);

                return StatusCode(StatusCodes.Status200OK, deletedPost);
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

        [HttpDelete("{postId}/comments/{commentId}")]
        public IActionResult DeleteComment(int postId, int commentId, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var deletedComment = commentService.DeleteComment(commentId, user);

                return StatusCode(StatusCodes.Status200OK, deletedComment);
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

        [HttpGet("{postId}/comments")]
        public IActionResult GetAllCommentsFromPost(int postId)
        {
            try
            {
                var comments = postService.GetCommentsByPost(postId);

                return StatusCode(StatusCodes.Status200OK, comments);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpGet("{postId}/comments/{commentId}")]
        public IActionResult GetCommentFromPost(int postId, int commentId)
        {
            try
            {
                var comment = postService.GetCommentFromPost(postId, commentId);
                return Ok(comment);
            }
            catch (EntityNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpDelete("{id}/comments")]
        public IActionResult DeleteAllCommentsForPost(int id)
        {
            try
            {
                postService.DeleteAllPostComments(id);
                return Ok("All comments for the post have been deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
                
        [HttpPost("{postId}/tags/{tagId}")]
        public IActionResult AddTagToPost(int postId, int tagId)
        {
            var success = postService.AddTagToPost(postId, tagId);

            if (success)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        [HttpPost("{postId}/likes")]
        public IActionResult LikePost(int postId, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var likedPost = postService.LikePost(postId, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<LikeResponseDto>(likedPost));
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

        [HttpDelete("{postId}/likes")]
        public IActionResult DislikePost(int postId, [FromHeader] string username)
        {
            try
            {
                User user = authManager.TryGetUser(username);
                var dislikedPost = postService.DislikePost(postId, user);

                return StatusCode(StatusCodes.Status200OK, mapper.Map<LikeResponseDto>(dislikedPost));
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

        [HttpGet("filter")]
        public IActionResult FilterPosts([FromQuery] SearchQueryParameters searchQueryParameters)
        {
            try
            {
                var filteredPosts = postService.FilterBy(searchQueryParameters );

                return Ok(filteredPosts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        
    }
}
