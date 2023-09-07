using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Mappers;
using ForumManagementSystem.Models;
using ForumManagementSystem.services;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagementSystem.CONTROLLERS
{
    [ApiController]
    [Route("api/posts")]
    public class postsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly PostMapper postMapper;
        private readonly AuthenticationHelper authenticationHelper;

        public postsController(IPostsService postService, PostMapper postMapper, AuthenticationHelper authenticationHelper)
        {
            this.postsService = postService;
            this.postMapper = postMapper;
            this.authenticationHelper = authenticationHelper;
        }

        [HttpGet]
        public List<Post> GetAll([FromHeader] string username)
        {
            return postsService.GetAll();
        }

        [HttpGet("/filter")]
        public List<Post> Filter([FromHeader] string username, [FromQuery] PostFitlerParameters fitlerParameters)
        {
            return postsService.Filter(fitlerParameters);
        }

        [HttpGet("{id}")]
        public Post GetById(int id)
        {
            try
            {
                return postsService.GetById(id);
            }
            catch (EntityNotFoundException e)
            {
                throw new EntityNotFoundException(StatusCodes.Status404NotFound.ToString());
            }
        }

        [HttpPost]
        public Post CreatePost([FromHeader] string username, [FromBody] PostDTO postDTO)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                Post post = postMapper.DtoToObject(postDTO, user);
                postsService.Create(post, user);
                return post;
            }
            catch (EntityNotFoundException e)
            {
                throw new EntityNotFoundException(StatusCodes.Status404NotFound.ToString());
            }
            catch (DuplicateEntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                throw new UnauthorizedOperationException("You are not allowed to create posts");
            }
        }

        [HttpPut("/update/{id}")]
        public Post UpdatePost([FromHeader] string username, int id, [FromBody] PostDTO postDTO)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                Post post = postMapper.DtoToObject(postDTO, user);
                postsService.Update(post, user, id);
                return post;
            }
            catch (EntityNotFoundException e)
            {
                throw new EntityNotFoundException(StatusCodes.Status404NotFound.ToString());
            }
            catch (DuplicateEntityException e)
            {
                throw new Exception(e.Message);
            }
            catch (UnauthorizedOperationException e)
            {
                throw new UnauthorizedOperationException("You are not allowed to create posts");
            }
        }

        [HttpDelete("{id}")]
        public void DeletePost([FromHeader] string username, int id)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                postsService.Delete(id, user);
            }
            catch (EntityNotFoundException e)
            {
                throw new EntityNotFoundException(StatusCodes.Status404NotFound.ToString());
            }
        }
    }
}
