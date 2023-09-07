using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public interface IBeersRepository
	{
		Beer GetByName(string name);
		Beer Create(Beer beer);
	}
}
