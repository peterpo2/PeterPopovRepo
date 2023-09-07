using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Services
{
	public interface IBeersService
	{
		Beer Create(Beer beer);
	}
}
