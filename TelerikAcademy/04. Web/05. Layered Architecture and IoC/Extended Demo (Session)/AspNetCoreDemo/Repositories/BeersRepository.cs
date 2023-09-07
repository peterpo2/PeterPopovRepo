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
		private readonly IStylesRepository stylesRepository;

		public BeersRepository(IStylesRepository stylesRepository)
		{
			this.stylesRepository = stylesRepository;

			this.beers = new List<Beer>()
			{
				new Beer
				{
					Id = 1,
					Name = "Glarus English Ale",
					Abv = 4.6,
					Style = this.stylesRepository.GetById(1), // Special Ale
				},
				new Beer
				{
					Id = 2,
					Name = "Rhombus Porter",
					Abv = 5.0,
					Style = this.stylesRepository.GetById(2), // English Porter
				},
				new Beer
				{
					Id = 3,
					Name = "Opasen Char",
					Abv = 6.6,
					Style = this.stylesRepository.GetById(3), // Indian Pale Ale
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

			return beer ?? throw new EntityNotFoundException($"Beer with name={name} doesn't exist."); ;
		}

		public List<Beer> FilterBy(BeerQueryParameters filterParameters)
		{
			List<Beer> result = this.beers;

			if (!string.IsNullOrEmpty(filterParameters.Name))
			{
				result = result.FindAll(beer => beer.Name.Contains(filterParameters.Name));
			}

			if (filterParameters.MinAbv.HasValue)
			{
				result = result.FindAll(beer => beer.Abv >= filterParameters.MinAbv);
			}

			if (filterParameters.MaxAbv.HasValue)
			{
				result = result.FindAll(beer => beer.Abv <= filterParameters.MaxAbv);
			}

			if (!string.IsNullOrEmpty(filterParameters.SortBy))
			{
				if (filterParameters.SortBy.Equals("name", StringComparison.InvariantCultureIgnoreCase))
				{
					result = result.OrderBy(beer => beer.Name).ToList();
				}
				else if (filterParameters.SortBy.Equals("abv", StringComparison.InvariantCultureIgnoreCase))
				{
					result = result.OrderBy(beer => beer.Abv).ToList();
				}

				if (!string.IsNullOrEmpty(filterParameters.SortOrder) && filterParameters.SortOrder.Equals("desc", StringComparison.InvariantCultureIgnoreCase))
				{
					result.Reverse();
				}
			}

			return result;
		}

		public Beer Create(Beer beer)
		{
            beer.Id = this.beers.Count + 1;
            this.beers.Add(beer);
			
			return beer;
		}

		public Beer Update(int id, Beer beer)
		{
			Beer beerToUpdate = this.GetById(id);
			beerToUpdate.Name = beer.Name;
			beerToUpdate.Abv = beer.Abv;
			beerToUpdate.Style = beer.Style;

			return beerToUpdate;
		}

		public Beer Delete(int id)
		{
			Beer beerToDelete = this.GetById(id);
			this.beers.Remove(beerToDelete);

			return beerToDelete;
		}
	}
}
