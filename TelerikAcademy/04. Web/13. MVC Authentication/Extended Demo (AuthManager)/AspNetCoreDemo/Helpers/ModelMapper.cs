using AspNetCoreDemo.Models;

namespace AspNetCoreDemo.Helpers
{
	public class ModelMapper
	{
		public Beer Map(BeerDto dto)
		{
			return new Beer
			{
				Name = dto.Name,
				Abv = dto.Abv,
				StyleId = dto.StyleId
			};
		}

		public User Map(RegisterViewModel viewModel)
		{
			return new User
			{
				Username = viewModel.Username,
				Password = viewModel.Password
			};
		}
	}
}
