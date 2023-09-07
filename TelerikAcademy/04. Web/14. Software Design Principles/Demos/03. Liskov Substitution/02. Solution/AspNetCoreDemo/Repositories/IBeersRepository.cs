using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public interface IBeersRepository
	{
		Beer GetById(int id);
	}
}
