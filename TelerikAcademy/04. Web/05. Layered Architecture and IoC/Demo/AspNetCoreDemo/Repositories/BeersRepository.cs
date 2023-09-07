using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreDemo.Repositories
{
	public class BeersRepository : IBeersRepository
	{
		private readonly List<Beer> beers;

		public BeersRepository()
		{
			this.beers = new List<Beer>()
			{
				new Beer
				{
					Id = 1,
					Name = "Glarus English Ale",
					Abv = 4.6,
				},
				new Beer
				{
					Id = 2,
					Name = "Rhombus Porter",
					Abv = 5.0,
				},
				new Beer
				{
					Id = 3,
					Name = "Opasen Char",
					Abv = 6.6,
				}
			};
		}

		public List<Beer> GetAll()
		{
			return this.beers;
		}

		public Beer GetById(int id)
		{
			Beer beer = this.beers.Where(b => b.Id == id).FirstOrDefault();
			
			return beer ?? throw new EntityNotFoundException($"Beer with id={id} doesn't exist.");
		}

		public Beer GetByName(string name)
		{
			Beer beer = this.beers.Where(b => b.Name == name).FirstOrDefault();
			
			return beer ?? throw new EntityNotFoundException($"Beer with name={name} doesn't exist.");
		}

		public Beer Create(Beer beer)
		{
			this.beers.Add(beer);
			beer.Id = this.beers.Count;

			return beer;
		}

		public Beer Update(int id, Beer beer)
		{
			Beer beerToUpdate = this.GetById(id);
			beerToUpdate.Abv = beer.Abv;

			return beerToUpdate;
		}

		public void Delete(int id)
		{
			Beer existingBeer = this.GetById(id);
			this.beers.Remove(existingBeer);
		}
	}
}
