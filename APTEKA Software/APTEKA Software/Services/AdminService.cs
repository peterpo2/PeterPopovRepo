using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services.Contracts;

namespace APTEKA_Software.Services
{
    public class AdminService:IAdminService
    {
        private const string ModifyUserErrorMessage = "Only admin can midify an user.";
        private const string AdminErrorMessage = "This user is already admin.";

        private readonly IUserRepository userRepository;

        public AdminService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User BlockUser(int userId, User user)
        {
            if (user.IsAdmin)
            {
                var userToBlock = userRepository.GetUser(userId);

                userToBlock.IsBlocked = true;

                return userRepository.UpdateUser(userToBlock);
            }
            throw new UnauthorizedOperationException(ModifyUserErrorMessage);
        }

        public User UnblockUser(int userId, User user)
        {
            if (user.IsAdmin)
            {
                var userToUnblock = userRepository.GetUser(userId);

                userToUnblock.IsBlocked = false;

                return userRepository.UpdateUser(userToUnblock);
            }
            throw new UnauthorizedOperationException(ModifyUserErrorMessage);
        }

        public User AssignAdminRole(int id, User user)
        {
            if (user.IsAdmin)
            {
                var existingUser = userRepository.GetUser(id);
                if (existingUser.IsAdmin)
                {
                    throw new DuplicateEntityException(AdminErrorMessage);
                }
                existingUser.IsAdmin = true;

                return userRepository.UpdateUser(existingUser);
            }
            throw new UnauthorizedOperationException(ModifyUserErrorMessage);
        }

        public User RemoveAdminRole(int id, User user)
        {
            if (user.IsAdmin)
            {
                var existingUser = userRepository.GetUser(id);
                if (!existingUser.IsAdmin)
                {
                    throw new DuplicateEntityException("This user is not an admin.");
                }
                existingUser.IsAdmin = false;

                return userRepository.UpdateUser(existingUser);
            }
            throw new UnauthorizedOperationException(ModifyUserErrorMessage);
        }
    }
}
