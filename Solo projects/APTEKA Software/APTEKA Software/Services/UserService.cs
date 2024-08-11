using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;
using APTEKA_Software.Exeptions;
using System.Reflection;
using APTEKA_Software.Repositories;

namespace APTEKA_Software.Services
{
    public class UserService : IUserService
    {
        private const string ModifyUserErrorMessage = "Only owner can modify a user.";
        private const string DuplicateUsernameErrorMessage = "Username '{0}' is already taken.";

        private readonly IUserRepository userRepository;
        private readonly ISaleRepository salesRepository;
        private readonly IDeliveryRepository deliveryRepository;

        public UserService(IUserRepository userRepository,ISaleRepository salesRepository, IDeliveryRepository deliveryRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            this.deliveryRepository = deliveryRepository ?? throw new ArgumentNullException(nameof(deliveryRepository));
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
            return userRepository.GetAllUsers().ToList(); 
        }


        public User CreateUser(User user)
        {
            if (userRepository.CheckUsername(user.Username))
            {
                throw new DuplicateEntityException(string.Format(DuplicateUsernameErrorMessage, user.Username));
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
            if (newUserInfo.Username is not null)
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
            if (userToDelete == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            if (!userToDelete.Equals(user) && !user.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyUserErrorMessage);
            }

            // Check if the user has deliveries or sales
            bool hasDeliveries = deliveryRepository.HasDeliveries(id);
            bool hasSales = salesRepository.HasSales(id);

            if (!hasDeliveries && !hasSales)
            {
                // If the user has neither deliveries nor sales, simply delete the user
                return userRepository.DeleteUser(id);
            }

            // If the user has only deliveries or sales, notify the admin
            if (hasDeliveries && !hasSales)
            {
                throw new InvalidOperationException("The user has only deliveries. Please reassign them before deleting.");
            }
            else if (!hasDeliveries && hasSales)
            {
                throw new InvalidOperationException("The user has only sales. Please reassign them before deleting.");
            }

            // If the user has both deliveries and sales, return false as deletion should not proceed without reassignment
            return false;
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
        public void ReassignUserRecords(int oldUserId, int newUserId)
        {
            var oldUser = userRepository.GetUser(oldUserId);
            var newUser = userRepository.GetUser(newUserId);

            if (oldUser == null || newUser == null)
            {
                throw new InvalidOperationException("Invalid user(s) selected for reassignment.");
            }

            deliveryRepository.ReassignDeliveries(oldUserId, newUserId);
            salesRepository.ReassignSales(oldUserId, newUserId);
            userRepository.DeleteUser(oldUserId);
        }


    }
}
