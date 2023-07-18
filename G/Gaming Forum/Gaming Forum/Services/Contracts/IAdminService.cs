using Gaming_Forum.Models;

namespace Gaming_Forum.Services.Contracts
{
    public interface IAdminService
    {
        User BlockUser(int userId, User user);

        User UnblockUser(int userId, User user);

        User AssignAdminRole(int id, User user);

        User RemoveAdminRole(int id, User user);
    }
}
