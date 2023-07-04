﻿using AutoMapper;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Helpers;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers.API
{
    [Route("api/Users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AuthManager authManager;
        private readonly IMapper mapper;

        public UserApiController(IUserService userService, IMapper mapper, AuthManager authManager)
        {
            this.userService = userService;
            this.authManager = authManager;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = userService.GetUser(id);

                return Ok(mapper.Map<UserResponseDto>(user));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("username/{username}")]
        public IActionResult GetUserByUsername(string username)
        {
            try
            {
                var user = userService.GetUserByUsername(username);

                return Ok(mapper.Map<UserResponseDto>(user));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                var user = userService.GetUserByEmail(email);

                return Ok(mapper.Map<UserResponseDto>(user));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = userService.GetAllUsers().Select(u => mapper.Map<UserResponseDto>(u)).ToList();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreatedDto user)
        {
            try
            {
                var newUser = mapper.Map<User>(user);
                userService.CreateUser(newUser);
                return Ok(mapper.Map<UserResponseDto>(newUser));
            }
            catch(DuplicateEntityException ex)
            {
                return Forbid(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromHeader] string username, [FromBody] UserUpdateDto newUserInfo)
        {
            try
            {
                var user = authManager.TryGetUser(username);
                var updatetedUser = userService.UpdateUser(id, mapper.Map<User>(newUserInfo), user);
                return Ok(mapper.Map<UserResponseDto>(updatetedUser));
            }
            catch (UnauthorizedOperationException e)
            {
                return Conflict(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id, [FromHeader] string username)
        {
            try
            {
                var user = authManager.TryGetUser(username);
                userService.DeleteUser(id, user);
                return Ok();
            }
            catch (UnauthorizedOperationException e)
            {
                return Forbid(e.Message);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return Conflict(e.Message);
            }
        }
    }
}
