using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Mappers;
using ForumManagementSystem.Models;
using ForumManagementSystem.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForumManagementSystem.CONTROLLERS
{
    [Route("api/comments/comment")]
    [ApiController]
    public class commentController : ControllerBase
    {
        private readonly ICommentsService service;
        private readonly CommentMapper mapper;
        private readonly AuthenticationHelper authenticationHelper;



        public commentController(ICommentsService service, CommentMapper mapper, AuthenticationHelper authenticationHelper)
        {
            this.service = service;
            this.mapper = mapper;



            this.authenticationHelper = authenticationHelper;
        }



        // TODO Fix formatting on method params. Fix endpoint
        // TODO What do we do with commented code?
        [HttpGet("/getAllComments")]
        public List<Comment> GetAll(string author, string pos, string dat, string sort, string sortOrder)
        {


            // To be implemented
            // return service.GetAll(author, pos, dat, sort, sortOrder);
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public Comment GetById(int id)
        {
            try
            {
                return service.GetById(id);
            }
            catch (EntityNotFoundException e)
            {
                throw new EntityNotFoundException(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CREATE([FromHeader] string username, CommentDTO commentDto)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                Comment comment = mapper.dtoToObject(commentDto, user);
                service.Create(comment, user);
                return StatusCode(StatusCodes.Status201Created, comment);
            }
            catch (UnauthorizedOperationException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Comment comment, int id)
        {
            service.Update(comment, id);
            return Ok(comment);
        }

        // TODO Should there be explanation why this method is commented?
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    service.Delete(id);
        //}

        // Doesn't Work. To be deleted.
        //[HttpGet("/{id}/likes")]
        //public List<Post> Likes([FromHeader] string username, int id)
        //{
        //    List<Post> result = new List<Post>();
        //    try
        //    {
        //        User user = authenticationHelper.TryGetUser(username);
        //        if (user.IsAdmin || user.Id == id)
        //        {
        //            result = new List<Post>(GetById(id).Likes);
        //        }
        //    } 
        //    catch (UnauthorizedOperationException e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return result;
        //}
    }
}
