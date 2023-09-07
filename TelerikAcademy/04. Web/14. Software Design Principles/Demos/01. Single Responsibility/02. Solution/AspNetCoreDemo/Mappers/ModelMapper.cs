using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

namespace AspNetCoreDemo.Mappers
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
			Beer model = new Beer();
			model.Abv = dto.Abv;
			model.Name = dto.Name;
			model.Style = this.stylesService.GetById(dto.StyleId);
			return model;
		}
	}
}
