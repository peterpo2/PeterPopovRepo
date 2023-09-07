using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IService<User> usersService;

		public UsersController(IService<User> usersService)
		{
			this.usersService = usersService;
		}
	}
}