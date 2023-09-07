using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BeersController : ControllerBase
	{
		private readonly IService<Beer> beersService;

		public BeersController(IService<Beer> usersService)
		{
			this.beersService = usersService;
		}
	}
}