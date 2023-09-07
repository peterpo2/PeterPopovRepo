using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly List<User> users;

		public UsersRepository()
		{
			this.users = new List<User>()
			{
				new User
				{
					Id = 1,
					Username = "admin",
					Password = "MTIz",
                    IsAdmin = true
				},
				new User
				{
					Id = 2,
					Username = "george",
                    Password = "MTIz",
                    IsAdmin = false
				},
				new User
				{
					Id = 3,
					Username = "peter",
                    Password = "MTIz",
                    IsAdmin = false
				}
			};
		}

		public List<User> GetAll()
		{
			return this.users;
		}

		public User GetById(int id)
		{
			User user = this.users.Where(u => u.Id == id).FirstOrDefault();
			
			return user ?? throw new EntityNotFoundException($"User with id={id} doesn't exist.");
		}

		public User GetByUsername(string username)
		{
			User user = this.users.Where(u => u.Username == username).FirstOrDefault();
			
			return user ?? throw new EntityNotFoundException($"User with username={username} doesn't exist.");
		}

        public User Promote(User user)
        {
            if (!user.IsAdmin)
            {
                user.IsAdmin = true;
            }

            return user;
        }
    }
}
