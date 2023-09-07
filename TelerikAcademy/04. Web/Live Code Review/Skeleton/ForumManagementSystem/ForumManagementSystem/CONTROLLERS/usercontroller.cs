using ForumManagementSystem.data;
using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Mappers;
using ForumManagementSystem.Models;
using ForumManagementSystem.services;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace ForumManagementSystem.CONTROLLERS
{
    [ApiController]
    [Route("api/users")]
    public class usercontroller : ControllerBase
    {

        private readonly IUsersService service;

        private readonly UserMapper userMapper;

        private readonly AuthenticationHelper authenticationHelper;

        private readonly ApplicationContext context;


        public usercontroller(IUsersService service, UserMapper userMapper, AuthenticationHelper authenticationHelper, ApplicationContext context)
        {

            this.service = service;
            this.userMapper = userMapper;

            this.authenticationHelper = authenticationHelper;
            this.context = context;
        }

        [HttpGet]
        public List<User> GetAll([FromHeader] string username, [FromQuery] UserQueryParameters queryParameters) {


            try {
                User user = authenticationHelper.TryGetUser(username);
                return service.GetAll(user, queryParameters);
            }
            catch (UnauthorizedOperationException e) {
                throw new Exception(e.Message);
            }

        }

        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(user => user.Id == id);
        }

        // TODO. What do we do with commented code?
        // ne go mahai, shte mi trqbwa.

        //[HttpGet("{id}/likes")]
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
        //        throw new Exception(StatusCodes.Status401Unauthorized.ToString());
        //    }
        //}

        public User createUser(UserDTO userDto)
        {
            try
            {
                User user = service.Create(userDto);
                return user;
            }
            catch (DuplicateEntityException ex)
            {
                return null;
            }
        }

        [HttpPut("{id}")]
        public User UpdateUser(int id, UserDTO userDTO, [FromHeader] string username)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                User userToUpdate = userMapper.fromDto(userDTO, id);
                service.Update(id, userToUpdate, user);
                return userToUpdate;
            }
            catch (UserNotFoundException e)
            {
                throw new Exception(StatusCodes.Status404NotFound.ToString());
            }
            catch (UnauthorizedOperationException e)
            {
                throw new UnauthorizedOperationException(StatusCodes.Status401Unauthorized.ToString());
            }
        }

        [HttpPut("{userId}/demote")]
        public void Demote(int userId, [FromHeader] string username)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                service.Demote(userId, user);
            }
            catch (UserNotFoundException e)
            {
                throw new Exception(StatusCodes.Status404NotFound.ToString());
            }
            catch (UnauthorizedOperationException e)
            {
                throw new UnauthorizedOperationException(StatusCodes.Status401Unauthorized.ToString());
            }
        }

        [HttpPut("{userId}/block")]
        public void Block(int userId, [FromHeader] string username)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                service.Block(userId, user);
            }
            catch (UserNotFoundException e)
            {
                throw new Exception(StatusCodes.Status404NotFound.ToString());
            }
            catch (UnauthorizedOperationException e)
            {
                throw new UnauthorizedOperationException(StatusCodes.Status401Unauthorized.ToString());
            }
        }

        [HttpPut("{userId}/unblock")]
        public void Unblock(int userId, [FromHeader] string username)
        {
            try
            {
                User user = authenticationHelper.TryGetUser(username);
                service.Unblock(userId, user);
            }
            catch (UserNotFoundException e)
            {
                throw new Exception(StatusCodes.Status404NotFound.ToString());
            }
            catch (UnauthorizedOperationException e)
            {
                throw new UnauthorizedOperationException(StatusCodes.Status401Unauthorized.ToString());
            }
        }
    }
}
