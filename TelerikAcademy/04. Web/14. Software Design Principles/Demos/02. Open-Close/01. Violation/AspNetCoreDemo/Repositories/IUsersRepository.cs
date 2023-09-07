
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public interface IUsersRepository
	{
		User GetById(int id);
	}
}
