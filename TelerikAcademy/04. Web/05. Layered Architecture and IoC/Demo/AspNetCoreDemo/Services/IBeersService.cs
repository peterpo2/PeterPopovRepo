using AspNetCoreDemo.Models;

using System.Collections.Generic;

namespace AspNetCoreDemo.Services
{
	public interface IBeersService
	{
		List<Beer> GetAll();
		Beer GetById(int id);
		Beer Create(Beer beer);
		Beer Update(int id, Beer beer);
		void Delete(int id);
	}
}
