using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Gaming_Forum.Data.Repositories
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
            var user = context.Users.Include(u => u.Comments)
                                        .ThenInclude(c => c.Post)
                                            .ThenInclude(p => p.User)
                                    .Include(u => u.Comments)
                                        .ThenInclude(c => c.Likes)
                                            .ThenInclude(l => l.User)
                                    .Include(u => u.Posts)
                                        .ThenInclude(p => p.Comments)
                                    .Include(u => u.Posts)
                                        .ThenInclude(p => p.Likes)
                                    .Include(u => u.Likes)
                                        .ThenInclude(l => l.Post)
                                    .Include(u => u.Likes)
                                        .ThenInclude(l => l.Comment)
                                    .FirstOrDefault(u => u.Id == id);
            if (user == null || user.IsDeleted)
            {
                throw new EntityNotFoundException($"User with id={id} not found.");
            }
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = context.Users.Include(u => u.Comments)
                                        .ThenInclude(c => c.Post)
                                            .ThenInclude(p => p.User)
                                    .Include(u => u.Comments)
                                        .ThenInclude(c => c.Likes)

                                    .Include(u => u.Posts)
                                        .ThenInclude(p => p.Comments)
                                    .Include(u => u.Posts)
                                        .ThenInclude(p => p.Likes)
                                    .Include(u => u.Likes)
                                        .ThenInclude(l => l.Post)
                                    .Include(u => u.Likes)
                                        .ThenInclude(l => l.Comment)
                                    .FirstOrDefault(u => u.Username == username);
            if (user == null || user.IsDeleted)
            {
                throw new EntityNotFoundException($"User with username='{username}' not found.");
            }
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = context.Users.Include(u => u.Comments)
                                        .ThenInclude(c => c.Post)
                                            .ThenInclude(p => p.User)
                                    .Include(u => u.Posts)
                                        .ThenInclude(p => p.Comments)
                                    .Include(u => u.Posts)
                                        .ThenInclude(p => p.Likes)
                                    .Include(u => u.Likes)
                                        .ThenInclude(l => l.Post)
                                    .Include(u => u.Likes)
                                        .ThenInclude(l => l.Comment)
                                    .FirstOrDefault(u => u.Email == email);
            if (user == null || user.IsDeleted)
            {
                throw new EntityNotFoundException($"User with email='{email}' not found.");
            }
            return user;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.Include(u => u.Comments)
                                    .ThenInclude(c => c.Post)
                                        .ThenInclude(p => p.User)
                                .Include(u => u.Posts)
                                    .ThenInclude(p => p.Comments)
                                .Include(u => u.Posts)
                                    .ThenInclude(p => p.Likes)
                                .Include(u => u.Likes)
                                    .ThenInclude(l => l.Post)
                                .Include(u => u.Likes)
                                    .ThenInclude(l => l.Comment)
                                .ToList();
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

        public User CreateUser(User user)
        {
            user.CreatedDate = DateTime.Now;
            var createdUser = context.Users.Add(user);
            context.SaveChanges();
            return createdUser.Entity;
        }

        public bool AssignAdminRole(int userId)
        {
            var user = this.GetUser(userId);
            user.IsAdmin = true;
            context.Update(user);
            context.SaveChanges();
            return true;
        }

        public bool RemoveAdminRole(int userId)
        {
            var user = this.GetUser(userId);
            user.IsAdmin = false;
            context.Update(user);
            context.SaveChanges();
            return true;
        }
        public bool CheckUsername(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }
        public bool CheckEmail(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }
    }
}
