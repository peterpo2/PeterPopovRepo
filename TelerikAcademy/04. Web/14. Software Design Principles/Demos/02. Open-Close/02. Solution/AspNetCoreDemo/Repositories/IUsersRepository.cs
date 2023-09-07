
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public interface IUsersRepository
	{
		BaseUser GetById(int id);
	}
}
