
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class BeersService : IBeersService
	{
		private readonly IBeersRepository repository;

		public BeersService(IBeersRepository repository)
		{
			this.repository = repository;
		}

		public Beer Create(Beer beer)
		{
			bool duplicateExists = true;

			try
			{
				this.repository.GetByName(beer.Name);
			}
			catch (EntityNotFoundException)
			{
				duplicateExists = false;
			}

			if (duplicateExists)
			{
				throw new DuplicateEntityException();
			}

			var createdBeer = this.repository.Create(beer);
			return createdBeer;
		}
	}
}
