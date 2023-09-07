using ForumManagementSystem.Models;

namespace ForumManagementSystem.Repositories
{
    public interface IPostsRepository
    {
        List<Post> GetAll();
        Post GetByPostId(int id);

        Post GetByTitle(string title);

        void Create(Post post, User author);

        void Update(Post post);

        void Delete(int id);

        List<Post> Filter(PostFitlerParameters fitlerParameters);

        List<Post> GetAllPostsByUser(User user);

    }
}
