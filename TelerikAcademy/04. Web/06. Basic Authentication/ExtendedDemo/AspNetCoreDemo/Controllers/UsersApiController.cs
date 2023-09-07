using System;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private AuthManager authManager;
        private IUsersService usersService;

        public UsersApiController(AuthManager authManager, IUsersService userService) 
        {
            this.authManager = authManager;
            this.usersService = userService;
        }

        [HttpPut("{id}/promote")]
        public IActionResult Promote(int id, [FromHeader] string credentials) 
        {

            try
            {
                var loggedUser = authManager.TryGetUser(credentials);
                if (loggedUser.IsAdmin)
                {
                    var user = this.usersService.GetById(id);

                    var promotedUser = this.usersService.Promote(user);

                    return StatusCode(StatusCodes.Status200OK, promotedUser);
                }
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }

            


        }
    }
}
