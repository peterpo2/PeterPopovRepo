using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;

namespace APTEKA_Software.Repositories.Contracts
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUserByUsername(string username);
        //List<User> GetAllUsers();
        IQueryable<User> GetAllUsers();
        User CreateUser(User user);
        User UpdateUser(User user);
        bool DeleteUser(int id);
        bool CheckUsername(string username);
    }
}
