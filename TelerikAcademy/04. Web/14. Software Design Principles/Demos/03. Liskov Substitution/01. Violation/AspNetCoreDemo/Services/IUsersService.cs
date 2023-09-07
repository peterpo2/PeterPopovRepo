
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services
{
	public interface IUsersService
	{
		IUser GetById(int id);
	}
}
