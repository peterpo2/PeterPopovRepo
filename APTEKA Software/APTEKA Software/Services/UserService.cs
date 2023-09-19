using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;
using APTEKA_Software.Exeptions;

namespace APTEKA_Software.Services
{
    public class UserService:IUserService
    {
        private const string ModifyUserErrorMessage = "Only owner can modify a user.";
        private const string DuplicateUsernameErrorMessage = "Username '{0}' is already taken.";

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public User GetUserByUsername(string username)
        {
            return userRepository.GetUserByUsername(username);
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User CreateUser(User user)
        {
            if (userRepository.CheckUsername(user.Username))
            {
                throw new DuplicateEntityException(string.Format(DuplicateUsernameErrorMessage, user.Username));
            }

            return userRepository.CreateUser(user);
        }

        public User UpdateUser(int id, User newUserInfo)
        {
            var userToUpdate = userRepository.GetUser(id);
            if(newUserInfo.Username is not null)
            {
                userToUpdate.Username = newUserInfo.Username;
            }
            if (newUserInfo.FirstName is not null)
            {
                userToUpdate.FirstName = newUserInfo.FirstName;
            }
            if (newUserInfo.LastName is not null)
            {
                userToUpdate.LastName = newUserInfo.LastName;
            }
            if (newUserInfo.Password is not null)
            {
                userToUpdate.Password = newUserInfo.Password;
            }
            return userRepository.UpdateUser(userToUpdate);
        }

        public bool DeleteUser(int id, User user)
        {
            var userToDelete = userRepository.GetUser(id);
            if (!userToDelete.Equals(user))
            {
                throw new UnauthorizedOperationException(ModifyUserErrorMessage);
            }

            return userRepository.DeleteUser(id);
        }
        public bool UsernameExists(string username)
        {
            bool usernameExists = true;

            try
            {
                _ = this.userRepository.GetUserByUsername(username);
            }
            catch (EntityNotFoundException)
            {
                usernameExists = false;
            }

            return usernameExists;
        }
    }
}
