using ForumManagementSystem.Models;

namespace ForumManagementSystem.services
{
    public interface IUsersService
    {
        List<User> GetAll(User user, UserQueryParameters queryParameters);
        List<User> Filter(UserQueryParameters queryParameters);


        User GetById(int id);

        User GetByUsername(String username);


        User Create(UserDTO userDTO);

        void Update(int id, User user, User user1);

        //    void delete(int id, User user);

        void Promote(int id, User user, Phone phone);

        void Demote(int id, User user);

        void Block(int id, User user);

        void Unblock(int id, User user);

        public int GetUsersCount();

        //List<User> filter(User user, Optional<String> firstName, Optional<String> lastName, Optional<String> username, Optional<String> email, Optional<String> sort);

        //List<User> filter(User user, Optional<String> search, Optional<UserSortOption> sort);
    }
}
