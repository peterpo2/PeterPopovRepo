using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Data;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

using Microsoft.EntityFrameworkCore;

namespace AspNetCoreDemo.Repositories
{
	public class StylesRepository : IStylesRepository
	{
		private readonly ApplicationContext context;

		public StylesRepository(ApplicationContext context)
		{
			this.context = context;
		}

		public List<Style> GetAll()
		{
			return GetStyles().ToList();
		}

		public Style GetById(int id)
		{
			Style style = GetStyles().Where(style => style.Id == id).FirstOrDefault();

			return style ?? throw new EntityNotFoundException($"Style with id={id} doesn't exist.");
		}

		private IQueryable<Style> GetStyles()
		{
			return context.Styles
						.Include(style => style.Beers)
							.ThenInclude(beer => beer.Ratings)
								.ThenInclude(rating => rating.User);
		}
	}
}
