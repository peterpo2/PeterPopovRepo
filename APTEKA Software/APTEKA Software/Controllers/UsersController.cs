using APTEKA_Software.Exeptions;
using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APTEKA_Software.Controllers
{
    public class UsersController : Controller
    {

        private readonly AuthManager authManager;
        private readonly IUserService usersService;
        private readonly IMapper modelMapper;

        public UsersController(AuthManager authManager, IUserService userService, IMapper modelMapper)
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

            User user = this.modelMapper.Map<User>(viewModel);
            this.usersService.CreateUser(user);

            return this.RedirectToAction("Login", "Users");
        }
        [HttpGet]
        public IActionResult Profile([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);

                return this.View(modelMapper.Map<RegisterViewModel>(user));
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost]
        public IActionResult Profile([FromRoute] int id, RegisterViewModel viewModel)
        {


            if (viewModel.Password != viewModel.ConfirmPassword)
            {
                this.ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");

                return this.View(viewModel);
            }
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }
            var updatedUser = this.usersService.UpdateUser(id, modelMapper.Map<User>(viewModel), this.authManager.CurrentUser);

            return this.View(modelMapper.Map<RegisterViewModel>(updatedUser));
        }
    }
}
