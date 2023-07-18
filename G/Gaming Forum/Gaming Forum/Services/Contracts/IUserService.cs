using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;

namespace Gaming_Forum.Services.Contracts
{
    public interface IUserService
    {
        User GetUser(int id);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        User CreateUser(User user);
        User UpdateUser(int id, User user, User sender);
        bool DeleteUser(int id, User user);
        bool UsernameExists(string username);
        bool EmailExists(string email);

	}
}
