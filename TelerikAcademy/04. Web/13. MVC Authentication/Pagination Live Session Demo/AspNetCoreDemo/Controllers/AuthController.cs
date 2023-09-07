using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.ViewModels;
using AspNetCoreDemo.Services;
using AspNetCoreDemo.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDemo.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthManager authManager;
        private readonly IUsersService usersService;

        public AuthController(AuthManager authManager, IUsersService usersService)
        {
            this.authManager = authManager;
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            try
            {
                var user = authManager.TryGetUser(loginViewModel.Username, loginViewModel.Password);
                this.HttpContext.Session.SetString("LoggedUser", user.Username);

                return RedirectToAction("Index", "Home");

            }
            catch (AuthenticationException ex)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                this.ViewData["ErrorMessage"] = ex.Message;

                return View(loginViewModel);
            }
            catch (UnauthorizedOperationException ex)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;

                return View(loginViewModel);
            }
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("LoggedUser");

            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();

            return View(registerViewModel);
        }

        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            if (usersService.UserExists(registerViewModel.Username))
            {
                this.ModelState.AddModelError("Username", "Username already exists");

                return View(registerViewModel);
            }

            if (registerViewModel.Password != registerViewModel.ConfirmPassword)
            {
                this.ModelState.AddModelError("ConfirmPassword", "Password doesn't match.");

                return View(registerViewModel);
            }

            var user = new User()
            {
                Username = registerViewModel.Username,
                Password = registerViewModel.Password
            };

            _ = usersService.Create(user);
            return RedirectToAction("Login", "Auth");
        }
    }
}
