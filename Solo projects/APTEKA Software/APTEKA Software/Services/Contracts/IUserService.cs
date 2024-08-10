using APTEKA_Software.Models;

namespace APTEKA_Software.Services.Contracts
{
    public interface IUserService
    {
        User GetUser(int id);
        User GetUserByUsername(string username);
        List<User> GetAllUsers();
        User CreateUser(User user);
        User UpdateUser(int id, User user, User sender);
        bool DeleteUser(int id, User user);
        bool UsernameExists(string username);
        void ReassignUserRecords(int oldUserId, int newUserId);
    }
}
