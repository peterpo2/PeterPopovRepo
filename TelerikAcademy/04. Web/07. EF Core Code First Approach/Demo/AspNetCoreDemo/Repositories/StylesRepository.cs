using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Data;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

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
			return this.context.Styles.ToList();
		}

		public Style GetById(int id)
		{
			Style style = this.context.Styles.Where(style => style.Id == id).FirstOrDefault();

			return style ?? throw new EntityNotFoundException($"Style with id={id} doesn't exist.");
		}
	}
}
