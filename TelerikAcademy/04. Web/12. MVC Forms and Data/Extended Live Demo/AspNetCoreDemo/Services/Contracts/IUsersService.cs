using System.Collections.Generic;

using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services.Contracts
{
    public interface IUsersService
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByUsername(string username);
    }
}
