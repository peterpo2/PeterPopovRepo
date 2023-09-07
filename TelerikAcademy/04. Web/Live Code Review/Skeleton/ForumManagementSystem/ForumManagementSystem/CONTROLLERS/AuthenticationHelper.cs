using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Models;
using ForumManagementSystem.services;

namespace ForumManagementSystem.CONTROLLERS
{
    public class AuthenticationHelper
    {
        private readonly IUsersService usersService;

        public AuthenticationHelper(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public User TryGetUser(string username)
        {
            try
            {
                return this.usersService.GetByUsername(username);
            }
            catch (EntityNotFoundException)
            {
                throw new UnauthorizedOperationException("Invalid username!");
            }
        }
    }
}
