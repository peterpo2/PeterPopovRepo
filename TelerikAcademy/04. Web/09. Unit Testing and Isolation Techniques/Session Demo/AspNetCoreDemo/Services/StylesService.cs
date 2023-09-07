using System.Collections.Generic;

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

		public List<Style> GetAll()
		{
			return repository.GetAll();
		}

		public Style GetById(int id)
		{
			return repository.GetById(id);
		}
	}
}
