using AspNetCoreDemo.Models;

using System.Collections.Generic;

namespace AspNetCoreDemo.Repositories
{
	public interface IBeersRepository
	{
		List<Beer> GetAll();
	}
}
