using AspNetCoreDemo.Data;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreDemo.Repositories
{
	public class BeersRepository : IBeersRepository
	{
		private readonly ApplicationContext context;

		public BeersRepository(ApplicationContext context)
		{
			this.context = context;
		}

		public List<Beer> GetAll()
		{
			return context.Beers
							.Include(b => b.Style)
							.Include(b => b.CreatedBy)
							.Include(b => b.Ratings)
								.ThenInclude(r => r.User)
							.ToList();
		}

		public Beer GetById(int id)
		{
			Beer beer = context.Beers.Where(b => b.Id == id).FirstOrDefault();

			return beer ?? throw new EntityNotFoundException($"Beer with id={id} doesn't exist.");
		}

		public Beer GetByName(string name)
		{
			Beer beer = context.Beers.Where(b => b.Name == name).FirstOrDefault();

			return beer ?? throw new EntityNotFoundException($"Beer with name={name} doesn't exist.");
		}

		public bool BeerExists(string name)
		{
			return context.Beers.Any(b => b.Name == name);
		}

		public List<Beer> FilterBy(BeerQueryParameters filterParameters)
		{
			IEnumerable<Beer> result = context.Beers;

			result = FilterByName(result, filterParameters.Name);
			result = FilterByMinAbv(result, filterParameters.MinAbv);
			result = FilterByMaxAbv(result, filterParameters.MaxAbv);
			result = SortBy(result, filterParameters.SortBy);
			result = Order(result, filterParameters.SortOrder);

			return result.ToList();
		}

		public Beer Create(Beer beer)
		{
			context.Beers.Add(beer);
			context.SaveChanges();

			return beer;
		}

		public Beer Update(int id, Beer beer)
		{
			Beer beerToUpdate = GetById(id);

			beerToUpdate.Name = beer.Name;
			beerToUpdate.Abv = beer.Abv;
			beerToUpdate.StyleId = beer.StyleId;

			context.Update(beerToUpdate);
			context.SaveChanges();

			return beerToUpdate;
		}

		public Beer Delete(int id)
		{
			Beer beerToRemove = GetById(id);
            Beer removedBeer = context.Beers.Remove(beerToRemove).Entity;
			context.SaveChanges();
			return removedBeer;
		}

		private static IEnumerable<Beer> FilterByName(IEnumerable<Beer> beers, string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				return beers.Where(beer => beer.Name.Contains(name));
			}
			else
			{
				return beers;
			}
		}

		private static IEnumerable<Beer> FilterByMinAbv(IEnumerable<Beer> beers, double? minAbv)
		{
			if (minAbv.HasValue)
			{
				return beers.Where(beer => beer.Abv >= minAbv);
			}
			else
			{
				return beers;
			}
		}

		private static IEnumerable<Beer> FilterByMaxAbv(IEnumerable<Beer> beers, double? maxAbv)
		{
			if (maxAbv.HasValue)
			{
				return beers.Where(beer => beer.Abv <= maxAbv);
			}
			else
			{
				return beers;
			}
		}

		private static IEnumerable<Beer> SortBy(IEnumerable<Beer> beers, string sortCriteria)
		{
			switch (sortCriteria)
			{
				case "name":
					return beers.OrderBy(beer => beer.Name);
				case "abv":
					return beers.OrderBy(beer => beer.Abv);
				// The following handles null or empty strings
				default:
					return beers;
			}
		}

		private static IEnumerable<Beer> Order(IEnumerable<Beer> beers, string sortOrder)
		{
			return (sortOrder == "desc") ? beers.Reverse() : beers;
		}
	}
}
