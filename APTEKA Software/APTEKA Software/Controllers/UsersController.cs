﻿using APTEKA_Software.Exeptions;
using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Models.ViewModels;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public IActionResult Index()
        {
            List<User> users = usersService.GetAllUsers().Where(u => !u.IsDeleted).ToList();
            List<UserViewModel> userViewModels = modelMapper.Map<List<UserViewModel>>(users);
            return View(userViewModels);
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
        public IActionResult Edit(int id)
        {
            User user = usersService.GetUser(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            EditUserViewModel viewModel = new EditUserViewModel
            {
                Id = user.UserId,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            User updatedUser = new User
            {
                UserId = viewModel.Id,
                Username = viewModel.Username,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };

            try
            {
                usersService.UpdateUser(id, updatedUser);

                return RedirectToAction("Index");
            }
            catch (UnauthorizedOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            User user = usersService.GetUser(id);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id, bool confirm)
        {
            User user = usersService.GetUser(id);
            
            try
            {
                if (confirm)
                {
                    usersService.DeleteUser(id, user);
                }

                return RedirectToAction("Index");
            }
            catch (UnauthorizedOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(user);
            }
        }
    }
}
