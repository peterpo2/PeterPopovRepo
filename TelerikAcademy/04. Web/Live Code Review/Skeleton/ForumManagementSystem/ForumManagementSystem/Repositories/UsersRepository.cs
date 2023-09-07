using ForumManagementSystem.data;
using ForumManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumManagementSystem.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext context;
        private readonly IPostsRepository postsRepository;

        public UsersRepository(ApplicationContext context, IPostsRepository postsRepository)
        {
            this.context = context;
            this.postsRepository = postsRepository;
        }

        public void Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public List<User> Filter(UserQueryParameters queryParameters)
        {
            IQueryable<User> result = GetUsers();

            result = FilterByFirstName(result, queryParameters.FirstName);
            result = FilterByLastName(result, queryParameters.LastName);
            result = FilterByUsername(result, queryParameters.Username);
            result = FilterByEmail(result, queryParameters.Email);
            result = SortBy(result, queryParameters.SortBy);
            result = Order(result, queryParameters.SortOrder);

            return result.ToList();
        }

        public List<User> GetAll()
        {
            return GetUsers().ToList();
        }

        //public List<Post> GetAllPostsByUser(int userId)
        //{
        //    return postsRepository.GetAll().Where(p => p.AuthorId == userId).ToList();
        //}

        public User GetByEmail(string email)
        {
            return GetUsers().FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return GetUsers().FirstOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string name)
        {
            return GetUsers().FirstOrDefault(u => u.Username == name);
        }

        public void Update(User user)
        {
            var userToUpdate = GetById(user.Id);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Username = user.Username;

            context.SaveChanges();
        }

        //public void Delete(User user)
        //{
        //    throw new NotSupportedException();
        //}

        private static IQueryable<User> FilterByLastName(IQueryable<User> users, string lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
            {
                return users.Where(user => user.LastName.Contains(lastName));
            }
            else
            {
                return users;
            }
        }

        private static IQueryable<User> FilterByFirstName(IQueryable<User> users, string firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                return users.Where(user => user.FirstName.Contains(firstName));
            }
            else
            {
                return users;
            }
        }

        private static IQueryable<User> FilterByUsername(IQueryable<User> users, string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                return users.Where(user => user.FirstName.Contains(username));
            }
            else
            {
                return users;
            }
        }

        private static IQueryable<User> FilterByEmail(IQueryable<User> users, string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return users.Where(user => user.FirstName.Contains(email));
            }
            else
            {
                return users;
            }
        }

        private static IQueryable<User> SortBy(IQueryable<User> users, string sortCriteria)
        {
            switch (sortCriteria)
            {
                case "firstname":
                    return users.OrderBy(user => user.FirstName);
                case "lastname":
                    return users.OrderBy(user => user.LastName);
                case "username":
                    return users.OrderBy(user => user.Username);
                case "email":
                    return users.OrderBy(user => user.Email);
                default:
                    return users;
            }
        }

        private static IQueryable<User> Order(IQueryable<User> users, string sortOrder)
        {
            return (sortOrder == "desc") ? users.Reverse() : users;
        }

        private IQueryable<User> GetUsers()
        {
            return context.Users
                .Include(u => u.Posts)
                .Include(u => u.Comments);
        }
    }
}
