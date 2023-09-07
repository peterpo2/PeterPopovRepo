using System.Collections.Generic;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories.Contracts;
using AspNetCoreDemo.Services.Contracts;

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

		public PaginatedList<Beer> FilterBy(BeerQueryParameters filterParameters)
		{
			return this.repository.FilterBy(filterParameters);
		}

		public Beer GetById(int id)
		{
			return this.repository.GetById(id);
		}

		public Beer Create(Beer beer, User user)
		{
			if (this.repository.BeerExists(beer.Name))
			{
				throw new DuplicateEntityException($"Beer {beer.Name} already exists.");
			}

			beer.CreatedById = user.Id;
			Beer createdBeer = this.repository.Create(beer);

			return createdBeer;
		}

		public Beer Update(int id, Beer beer, User user)
		{
			Beer beerToUpdate = this.repository.GetById(id);
			if (beerToUpdate.CreatedById != user.Id && !user.IsAdmin)
			{
				throw new UnauthorizedOperationException(ModifyBeerErrorMessage);
			}

			Beer updatedBeer = this.repository.Update(id, beer);

			return updatedBeer;
		}

		public Beer Delete(int id, User user)
		{
            Beer beer = repository.GetById(id);
            if (beer.CreatedById != user.Id && !user.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyBeerErrorMessage);
            }

            return this.repository.Delete(id);
        }
	}
}
