using APTEKA_Software.Data;
using APTEKA_Software.Exeptions;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace APTEKA_Software.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;
        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public User GetUser(int id)
        {
            var user = context.Users.Include(u => u.Items)
                                    .FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException($"User with id={id} not found.");
            }
            return user;
        }
        public User GetUserByUsername(string username)
        {
            var user = context.Users.Include(u => u.Items)
                                    .FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with username='{username}' not found.");
            }
            return user;
        }
        public List<User> GetAllUsers()
        {
            return context.Users.Include(u => u.Items).ToList();
        }
        public User CreateUser(User user)
        {
            user.DateRegistered = DateTime.Now;
            var createdUser = context.Users.Add(user);
            context.SaveChanges();
            return createdUser.Entity;
        }
        public User UpdateUser(User user)
        {
            var updatedUser = context.Users.Update(user);
            context.SaveChanges();
            return updatedUser.Entity;
        }
        public bool DeleteUser(int id)
        {
            var userToDelete = this.GetUser(id);
            userToDelete.IsDeleted = true;
            context.Update(userToDelete);
            context.SaveChanges();
            return true;
        }
        public bool CheckUsername(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }
    }
}
