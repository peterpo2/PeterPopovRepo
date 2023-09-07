using ForumManagementSystem.Models;
using ForumManagementSystem.Repositories;

namespace ForumManagementSystem.Mappers
{
    public class UserMapper
    {
        private readonly IUsersRepository usersRepository;

        public UserMapper(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public User fromDto(UserDTO userDto)
        {
            User user = new User();
            DateTime date = DateTime.Now;
            dtoToObject(user, userDto, date);
            return user;
        }


        public User fromDto(UserDTO userDTO, int id)
        {
            User user = usersRepository.GetById(id);
            DateTime date = user.Date;
            dtoToObject(user, userDTO, date);
            return user;
        }

        private void dtoToObject(User user, UserDTO userDto, DateTime date)
        {
            String newPassword = userDto.Password;

            user.FirstName  = userDto.FirstName;
            user.LastName = userDto.LastName;
            // user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            if (newPassword != null && !string.IsNullOrEmpty(newPassword)) user.Password = newPassword;
            user.Date = date;
            //
            // user.setLikes(new HashSet<>());
        }

        public User fromDto(RegisterDto registerDto)
        {
            User user = new User();
            user.Username = registerDto.Username;
            user.Password = registerDto.Password;
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.Email = registerDto.Email;
            user.IsAdmin = false;
          

            return user;
        }
    }
}
