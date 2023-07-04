using Gaming_Forum.Models;

namespace Gaming_Forum.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        User UpdateUser(User user);
        bool DeleteUser(int id);
        User CreateUser(User user);
        bool AssignAdminRole(int userId);
        bool RemoveAdminRole(int userId);
        bool CheckUsername(string username);
        bool CheckEmail(string email);
    }
}
