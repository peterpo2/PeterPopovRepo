
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services
{
	public interface IUsersService
	{
		T GetById<T>(int id) where T : IUser;
	}
}
