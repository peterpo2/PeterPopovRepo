using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly List<IUser> users = new List<IUser>();

		public UsersRepository(IBeersRepository beersRepository)
		{
			var admin = new Administrator
			{
				Id = 1,
				Username = "Administratarator",
				Email = "admin@daj-bozhe.com"
			};
			
			this.users.Add(admin);

			var customer = new Customer
			{
				Id = 2,
				Username = "pesho"
			};

			customer.AddFavouriteBeer(beersRepository.GetById(1));
			
			this.users.Add(customer);

			var employee = new Employee
			{
				Id = 3,
				Username = "gosho",
				Salary = 1234.56
			};

			this.users.Add(employee);
		}

		public IUser GetById(int id)
		{
			var user = this.users.Where(u => u.Id == id).FirstOrDefault();

			return user ?? throw new EntityNotFoundException();
		}
	}
}
