
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services
{
	public interface IUsersService
	{
		User GetById(int id);
		string GetDisplayInfo(User user);
	}
}
