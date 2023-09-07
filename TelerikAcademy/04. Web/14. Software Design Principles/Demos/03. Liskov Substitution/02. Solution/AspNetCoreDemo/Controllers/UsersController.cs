using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUsersService usersService;
		private readonly IBeersRepository beersRepo;

		public UsersController(IUsersService usersService, IBeersRepository beersRepo)
		{
			this.usersService = usersService;
			this.beersRepo = beersRepo;
		}

		// The link below adds a beer with id 3 (Opasen Char) to the favourites list of customer with id 2 (gosho),
		// http://localhost:5000/api/users/2/beers/add/3 
		[HttpGet("{userId}/beers/add/{beerId}")]
		public IActionResult AddToFavouriteBeers(int userId, int beerId)
		{
			try
			{
				ICustomer customer = this.usersService.GetById<ICustomer>(userId);
				Beer beer = this.beersRepo.GetById(beerId);
				customer.AddToFavourites(beer);

				return Redirect($"/api/users/{customer.Id}");
			}
			catch (EntityNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, $"Customer with id: {userId} doesn't exist!");
			}
		}

		[HttpGet("{userId}")]
		public IActionResult GetById(int userId)
		{
			IUser user = this.usersService.GetById<IUser>(userId);
			string userInfo = user.ToString();

			return this.StatusCode(StatusCodes.Status200OK, userInfo);
		}
	}
}