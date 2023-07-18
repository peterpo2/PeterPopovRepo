using Gaming_Forum.Data.Repositories;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Services
{
    public class UserService : IUserService
    {
        private const string ModifyUserErrorMessage = "Only owner or admin can modify a user.";
        private const string DuplicateUsernameErrorMessage = "Username '{1}' is already taken.";
        private const string DuplicateUserEmailErrorMessage = "Email '{1}' is already used.";


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

        public User GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
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
            if (userRepository.CheckEmail(user.Email))
            {
                throw new DuplicateEntityException(string.Format(DuplicateUserEmailErrorMessage, user.Email));
            }

            return userRepository.CreateUser(user);
        }

        public User UpdateUser(int id, User newUserInfo, User sender)
        {
            var userToUpdate = userRepository.GetUser(id);
            if (!userToUpdate.Username.Equals(sender) && !sender.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyUserErrorMessage);
            }
            
            if (newUserInfo.Email is not null)
            {
                if (newUserInfo.Email != sender.Email && userRepository.CheckEmail(newUserInfo.Email))
                {
                    throw new DuplicateEntityException("Email already exist.");
                }
                userToUpdate.Email = newUserInfo.Email;
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
            if (newUserInfo.PhoneNumber is not null)
            {
                userToUpdate.PhoneNumber = newUserInfo.PhoneNumber;
            }
            return userRepository.UpdateUser(userToUpdate);
        }

        public bool DeleteUser(int id, User user)
        {
            var userToDelete = userRepository.GetUser(id);
            if (!userToDelete.Equals(user) && !user.IsAdmin)
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
        public bool EmailExists(string email)
        {
            return this.userRepository.CheckEmail(email);
        }
    }
}
