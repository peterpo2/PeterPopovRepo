
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public interface IUsersRepository 
	{
		T GetById<T>(int id) where T : IUser;
	}
}
