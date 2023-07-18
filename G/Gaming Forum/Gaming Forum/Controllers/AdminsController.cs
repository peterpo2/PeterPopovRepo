using AutoMapper;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Helpers;
using Gaming_Forum.Models;
using Gaming_Forum.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers
{
    public class AdminsController : Controller
    {
        private readonly AuthManager authManager;
        private readonly IUserService usersService;
        private readonly IMapper modelMapper;
        private readonly IAdminService adminService;

        public AdminsController(AuthManager authManager, IUserService userService, IMapper modelMapper, IAdminService adminService)
        {
            this.authManager = authManager;
            this.usersService = userService;
            this.modelMapper = modelMapper;
            this.adminService = adminService;
        }
        [HttpGet]
        public IActionResult Index(string query, int pageNumber = 1, int pageSize = 5)
        {
            if (!this.authManager.CurrentUser.IsAdmin)
            {
                this.Response.StatusCode = StatusCodes.Status403Forbidden;
                this.ViewData["ErrorMessage"] = $"You cannot list all users since you are not an admin.";

                return this.View("Error");
            }

            var users = this.usersService.GetAllUsers().Where(u => u.IsDeleted == false);

            if (!string.IsNullOrEmpty(query))
            {
                users = users.Where(u => u.Username.Contains(query, StringComparison.OrdinalIgnoreCase));
            }

            var totalItems = users.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginatedUsers = users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new PaginatedList<User>(paginatedUsers, totalPages, pageNumber);

            return this.View(model);
        }


        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (this.authManager.CurrentUser == null)
                {
                    return this.RedirectToAction(actionName: "Login", controllerName: "Users");
                }

                var user = this.usersService.GetUser(id);

                return this.View(user);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);
                if (user.Id != this.authManager.CurrentUser.Id && !this.authManager.CurrentUser.IsAdmin)
                {
                    throw new UnauthorizedOperationException("Only the owner or an admin can delete this account.");
                }
                this.usersService.DeleteUser(user.Id, this.authManager.CurrentUser);

                return this.RedirectToAction("Index", "Admins");
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);

                return this.View(user);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, User user)
        {

            _ = this.usersService.UpdateUser(id, user, this.authManager.CurrentUser);

            return this.RedirectToAction("Index", "Admins");
        }
        [HttpGet]
        public IActionResult Block([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);

                return this.View(user);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost, ActionName("Block")]
        public IActionResult BlockConfirmed([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);
                if (!this.authManager.CurrentUser.IsAdmin)
                {
                    throw new UnauthorizedOperationException("Only an admin can block this account.");
                }
                this.adminService.BlockUser(user.Id, this.authManager.CurrentUser);

                return this.RedirectToAction("Index", "Admins");
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }
        [HttpGet]
        public IActionResult Unblock([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);

                return this.View(user);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost, ActionName("Unblock")]
        public IActionResult UnblockConfirmed([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);
                if (!this.authManager.CurrentUser.IsAdmin)
                {
                    throw new UnauthorizedOperationException("Only an admin can unblock this account.");
                }
                this.adminService.UnblockUser(user.Id, this.authManager.CurrentUser);

                return this.RedirectToAction("Index", "Admins");
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }
        [HttpGet]
        public IActionResult Promote([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);

                return this.View(user);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost, ActionName("Promote")]
        public IActionResult PromoteConfirmed([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);
                if (!this.authManager.CurrentUser.IsAdmin)
                {
                    throw new UnauthorizedOperationException("Only an admin can unblock this account.");
                }
                this.adminService.AssignAdminRole(user.Id, this.authManager.CurrentUser);

                return this.RedirectToAction("Index", "Admins");
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }
        [HttpGet]
        public IActionResult Demote([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);

                return this.View(user);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost, ActionName("Demote")]
        public IActionResult DemoteConfirmed([FromRoute] int id)
        {
            try
            {
                var user = this.usersService.GetUser(id);
                if (!this.authManager.CurrentUser.IsAdmin)
                {
                    throw new UnauthorizedOperationException("Only an admin can unblock this account.");
                }
                this.adminService.RemoveAdminRole(user.Id, this.authManager.CurrentUser);

                return this.RedirectToAction("Index", "Admins");
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }
    }
}
