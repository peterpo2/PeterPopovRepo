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
			this.styles = new List<Style>();
			this.styles.Add(new Style
			{
				Id = 1,
				Name = "Special Ale"
			});
			this.styles.Add(new Style
			{
				Id = 2,
				Name = "English Porter"
			});
			this.styles.Add(new Style
			{
				Id = 3,
				Name = "Indian Pale Ale"
			});
		}

		public Style GetById(int id)
		{
			var style = this.styles.Where(style => style.Id == id).FirstOrDefault();
			return style ?? throw new EntityNotFoundException();
		}
	}
}
