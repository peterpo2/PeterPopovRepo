using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

namespace AspNetCoreDemo.Helpers
{
	public class ModelMapper
	{
		private readonly IStylesService stylesService;

		public ModelMapper(IStylesService stylesService)
		{
			this.stylesService = stylesService;
		}

		public Beer Map(BeerDto dto)
		{
			return new Beer
			{
				Name = dto.Name,
				Abv = dto.Abv,
				Style = this.stylesService.GetById(dto.StyleId)
			};
		}
	}
}
