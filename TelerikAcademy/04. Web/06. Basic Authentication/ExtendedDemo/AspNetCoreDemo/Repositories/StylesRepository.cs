using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Repositories
{
	public class StylesRepository : IStylesRepository
	{
		private readonly List<Style> styles;

		public StylesRepository()
		{
			this.styles = new List<Style>()
			{
				new Style { Id = 1, Name = "Special Ale" },
				new Style { Id = 2, Name = "English Porter" },
				new Style { Id = 3, Name = "Indian Pale Ale" }
			};
		}

		public List<Style> GetAll()
		{
			return this.styles;
		}

		public Style GetById(int id)
		{
			Style style = this.styles.Where(s => s.Id == id).FirstOrDefault();

			return style ?? throw new EntityNotFoundException($"Style with id={id} doesn't exist.");
		}
	}
}
