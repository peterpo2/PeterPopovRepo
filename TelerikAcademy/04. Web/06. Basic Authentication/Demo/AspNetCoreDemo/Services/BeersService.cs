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
			return this.repository.GetAll();
		}

		public List<Beer> FilterBy(BeerQueryParameters filterParameters)
		{
			return this.repository.FilterBy(filterParameters);
		}

		public Beer GetById(int id)
		{
			return this.repository.GetById(id);
		}

		public Beer Create(Beer beer, User user)
		{
            if (repository.BeerExists(beer.Name))
            {
                throw new DuplicateEntityException($"Beer {beer.Name} already exists.");
            }

            beer.CreatedBy = user;
			Beer createdBeer = this.repository.Create(beer);

			return createdBeer;
		}

		public Beer Update(int id, Beer beer, User user)
		{
			Beer beerToUpdate = this.repository.GetById(id);
			if (!beerToUpdate.CreatedBy.Equals(user) && !user.IsAdmin)
			{
				throw new UnauthorizedOperationException(ModifyBeerErrorMessage);
			}

			Beer updatedBeer = this.repository.Update(id, beer);
			return updatedBeer;
		}

		public void Delete(int id, User user)
		{
			Beer beer = repository.GetById(id);
			if (!beer.CreatedBy.Equals(user) && !user.IsAdmin)
			{
				throw new UnauthorizedOperationException(ModifyBeerErrorMessage);
			}

			this.repository.Delete(id);
		}
	}
}
