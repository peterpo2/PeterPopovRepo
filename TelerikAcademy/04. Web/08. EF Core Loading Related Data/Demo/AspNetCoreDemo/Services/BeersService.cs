using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;

namespace AspNetCoreDemo.Services
{
	public class BeersService : IBeersService
	{
		private const string ModifyBeerErrorMessage = "Only owner or admin can modify a beer.";
		private readonly IBeersRepository repository;

		public BeersService(IBeersRepository repository)
		{
			this.repository = repository;
		}

		public List<Beer> GetAll()
		{
			return repository.GetAll();
		}

		public List<Beer> FilterBy(BeerQueryParameters filterParameters)
		{
			return repository.FilterBy(filterParameters);
		}

		public Beer GetById(int id)
		{
			return repository.GetById(id);
		}

		public Beer Create(Beer beer, User user)
		{
            if (repository.BeerExists(beer.Name))
            {
                throw new DuplicateEntityException($"Beer {beer.Name} already exists.");
            }

            beer.CreatedById = user.Id;
			Beer createdBeer = repository.Create(beer);

			return createdBeer;
		}

		public Beer Update(int id, Beer beer, User user)
		{
			Beer beerToUpdate = repository.GetById(id);
			if (!beerToUpdate.CreatedBy.Equals(user) && !user.IsAdmin)
			{
				throw new UnauthorizedOperationException(ModifyBeerErrorMessage);
			}

			Beer updatedBeer = repository.Update(id, beer);
			return updatedBeer;
		}

		public Beer Delete(int id, User user)
		{
			Beer beer = repository.GetById(id);
			if (!beer.CreatedBy.Equals(user) && !user.IsAdmin)
			{
				throw new UnauthorizedOperationException(ModifyBeerErrorMessage);
			}

			return repository.Delete(id);
		}
	}
}
