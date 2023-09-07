using ForumManagementSystem.Models;

namespace ForumManagementSystem.Repositories
{
    public interface IUsersRepository
    {
        List<User> GetAll();

        User GetById(int id);
        User GetByUsername(string name);
        User GetByEmail(string email);
        void Create(User user);
        void Update(User user);
        // void Delete(User user);
        List<User> Filter(UserQueryParameters queryParameters);
    }
}
