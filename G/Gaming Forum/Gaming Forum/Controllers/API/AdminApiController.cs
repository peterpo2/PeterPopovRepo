using AutoMapper;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Helpers;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers
{
    [ApiController]
    [Route("api/admins")]
    public class AdminApiController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly IMapper mapper;
        private readonly AuthManager authManager;

        public AdminApiController(IAdminService adminService, IMapper mapper, AuthManager authManager)
        {
            this.adminService = adminService;
            this.mapper = mapper;
            this.authManager = authManager;
        }


        [HttpPut("users/block/{userId}")]
        public IActionResult BlockUser(int userId, [FromHeader] string username)
        {
            try
            {
                var admin = authManager.TryGetUser(username);
                var blockedUser = adminService.BlockUser(userId, admin);
                return Ok(mapper.Map<UserResponseDto>(blockedUser));

            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("users/unblock/{userId}")]
        public IActionResult UnblockUser(int userId, [FromHeader] string username)
        {
            try
            {
                var admin = authManager.TryGetUser(username);
                var unBlockedUser = adminService.UnblockUser(userId, admin);
                return Ok(mapper.Map<UserResponseDto>(unBlockedUser));

            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("users/promote/{userId}")]
        public IActionResult PromoteUser(int userId, [FromHeader] string username)
        {
            try
            {
                var admin = authManager.TryGetUser(username);
                var promotedUser = adminService.AssignAdminRole(userId, admin);
                return Ok(mapper.Map<UserResponseDto>(promotedUser));

            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DuplicateEntityException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpPut("users/demote/{userId}")]
        public IActionResult DemoteUser(int userId, [FromHeader] string username)
        {
            try
            {
                var admin = authManager.TryGetUser(username);
                var demotedUser = adminService.RemoveAdminRole(userId, admin);
                return Ok(mapper.Map<UserResponseDto>(demotedUser));

            }
            catch (UnauthorizedOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DuplicateEntityException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

    }
}
