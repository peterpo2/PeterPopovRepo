using System.Collections.Generic;

using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class BeersService : IService<Beer>
	{
		private readonly IRepository<Beer> repository;

		public BeersService(IRepository<Beer> repository)
		{
			this.repository = repository;
		}

		public void Create(Beer beer)
		{
			this.repository.Create(beer);
		}

		public List<Beer> GetAll()
		{
			return this.repository.GetAll();
		}
	}
}
