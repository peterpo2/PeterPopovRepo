using System.Collections.Generic;

using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories.Contracts
{
    public interface IUsersRepository
    {
        List<User> GetAll();
        User GetById(int id);
        bool UserExists(string username);
        User Create(User user);

		User GetByUsername(string username);
    }
}
