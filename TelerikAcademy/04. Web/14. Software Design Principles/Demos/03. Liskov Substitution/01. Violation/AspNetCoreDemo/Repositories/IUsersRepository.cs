
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public interface IUsersRepository
	{
		IUser GetById(int id);
	}
}
