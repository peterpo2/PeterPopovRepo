
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class StylesService : IStylesService
	{
		private readonly IStylesRepository repository;

		public StylesService(IStylesRepository repository)
		{
			this.repository = repository;
		}

		public Style GetById(int id)
		{
			return this.repository.GetById(id);
		}
	}
}
