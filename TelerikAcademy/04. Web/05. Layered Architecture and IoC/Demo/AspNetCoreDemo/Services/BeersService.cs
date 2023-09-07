using System.Collections.Generic;

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

		public List<Beer> GetAll()
		{
			return this.repository.GetAll();
		}

		public Beer GetById(int id)
		{
			return this.repository.GetById(id);
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
				throw new DuplicateEntityException($"Beer {beer.Name} already exists.");
			}

			Beer createdBeer = this.repository.Create(beer);
			
			return createdBeer;
		}

		public Beer Update(int id, Beer beer)
		{
			bool duplicateExists = true;
			try
			{
				Beer existingBeer = this.repository.GetByName(beer.Name);
				
				if (existingBeer.Id == id)
				{
					duplicateExists = false;
				}
			}
			catch (EntityNotFoundException)
			{
				duplicateExists = false;
			}

			if (duplicateExists)
			{
				throw new DuplicateEntityException($"Beer {beer.Name} already exists.");
			}

			Beer updatedBeer = this.repository.Update(id, beer);
			
			return updatedBeer;
		}

		public void Delete(int id)
		{
			this.repository.Delete(id);
		}
	}
}
