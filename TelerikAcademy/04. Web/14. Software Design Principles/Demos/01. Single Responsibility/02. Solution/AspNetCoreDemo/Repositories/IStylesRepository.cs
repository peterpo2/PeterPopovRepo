
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public interface IStylesRepository
	{
		Style GetById(int id);
	}
}
