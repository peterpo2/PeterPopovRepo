using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Mappers;
using ForumManagementSystem.Models;
using ForumManagementSystem.Repositories;
using System;

namespace ForumManagementSystem.services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository repository;
        private readonly IPhoneRepository phoneRepository;
        private readonly UserMapper userMapper;

        public UsersService(IUsersRepository repository, IPhoneRepository phoneRepository, UserMapper userMapper)
        {
            this.repository = repository;
            this.phoneRepository = phoneRepository;
            this.userMapper = userMapper;
        }

        public void Block(int id, User user)
        {
            //  if (!user.IsAdmin) {
            //      throw new UnauthorizedOperationException("Only admin has rights to these action.");
            //  }
            User userToBlocked = repository.GetById(id);
            userToBlocked.IsBlocked = true;
            repository.Update(userToBlocked);
        }

        public User Create(UserDTO userDTO)
        {
            User user = userMapper.fromDto(userDTO);
            bool duplicateExists = true;
            try
            {
                repository.GetByUsername(user.Username);
            }
            catch (UserNotFoundException e)
            {
                duplicateExists = false;
            }
            if (duplicateExists)
            {
                throw new DuplicateEntityException("User", "username", user.Username);
            }
            duplicateExists = true;
            try
            {
                repository.GetByEmail(user.Email);
            }
            catch (UserNotFoundException e)
            {
                duplicateExists = false;
            }
            if (duplicateExists)
            {
                throw new DuplicateEntityException("User", "email", user.Email);
            }
            repository.Create(user);
            return user;
        }

        public void Demote(int id, User user)
        {
            // if (!user.IsAdmin) {
            //     throw new UnauthorizedOperationException("Only admin can receive such information.");
            // }

            User userToDemote = repository.GetById(id);
            userToDemote.IsAdmin = false;
            repository.Update(userToDemote);
        }

        public List<User> Filter(UserQueryParameters queryParameters)
        {
            return repository.Filter(queryParameters);
        }

        public List<User> GetAll(User user, UserQueryParameters queryParameters)
        {
            // if (!user.IsAdmin) {
            //     throw new UnauthorizedOperationException("Only admin can receive such information.");
            // }

            return repository.Filter(queryParameters);
        }

        public User GetById(int id)
        {
            return repository.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return repository.GetByUsername(username);
        }

        // TODO
        public int GetUsersCount()
        {
            List<User> users = repository.GetAll();
            int UserCount = users.Count;
            return UserCount;
        }

        public void Promote(int id, User user, Phone phone)
        {
            // if (!user.IsAdmin) {
            //     throw new UnauthorizedOperationException("Only admin can receive such information.");
            // }
            User userToPromote = repository.GetById(id);
            userToPromote.IsAdmin = true;
            userToPromote.Phone = phone;
            repository.Update(userToPromote);
        }

        public void Unblock(int id, User user)
        {
            //  if (!user.IsAdmin) {
            //      throw new UnauthorizedOperationException("Only admin has rights to these action.");
            //  }
            User userToBeUnblocked = repository.GetById(id);
            userToBeUnblocked.IsBlocked = false;
            repository.Update(userToBeUnblocked);
        }

        public void Update(int id, User userToBeUpdated, User user)
        {
            User existingUser;
            try
            {
                existingUser = repository.GetById(id);
            }
            catch (UserNotFoundException e)
            {
                throw new UserNotFoundException("User", id.ToString());
            }
            if (user.Id != id)
            {
                throw new UnauthorizedAccessException("Unauthorized to update other user.");
            }
            repository.Update(userToBeUpdated);
            if (!userToBeUpdated.Username.Equals(existingUser.Username))
            {
                throw new NotSupportedException("Username can not be updated.");
            }
        }
    }
}
