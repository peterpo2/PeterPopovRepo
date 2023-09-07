using AspNetCoreDemo.Services;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Web.Controllers
{
	public class UsersController : Controller
	{
		private readonly AuthManager authManager;
		private readonly IUsersService usersService;
		private readonly ModelMapper modelMapper;

		public UsersController(AuthManager authManager, IUsersService userService, ModelMapper modelMapper)
		{
			this.authManager = authManager;
			this.usersService = userService;
			this.modelMapper = modelMapper;
		}

		[HttpGet]
		public IActionResult Login()
		{
			var viewModel = new LoginViewModel();

			return this.View(viewModel);
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel viewModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(viewModel);
			}

			try
			{
				this.authManager.Login(viewModel.Username, viewModel.Password);

				return this.RedirectToAction("Index", "Home");
			}
			catch (UnauthorizedOperationException ex)
			{
				this.ModelState.AddModelError("Username", ex.Message);
				this.ModelState.AddModelError("Password", ex.Message);

				return this.View(viewModel);
			}
		}

		[HttpGet]
		public IActionResult Logout()
		{
			this.authManager.Logout();

			return this.RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Register()
		{
			var viewModel = new RegisterViewModel();

			return this.View(viewModel);
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel viewModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(viewModel);
			}

			if (this.usersService.UsernameExists(viewModel.Username))
			{
				this.ModelState.AddModelError("Username", "User with same username already exists.");

				return this.View(viewModel);
			}

			if (viewModel.Password != viewModel.ConfirmPassword)
			{
				this.ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

				return this.View(viewModel);
			}

			User user = this.modelMapper.Map(viewModel);
			this.usersService.Create(user);

			return this.RedirectToAction("Login", "Users");
		}
	}
}
