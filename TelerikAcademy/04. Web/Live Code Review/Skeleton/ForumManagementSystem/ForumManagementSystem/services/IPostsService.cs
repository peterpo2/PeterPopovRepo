using ForumManagementSystem.Models;

namespace ForumManagementSystem.services
{
    public interface IPostsService
    {
        List<Post> GetAll();

        Post GetById(int id);

        void Create(Post post, User author);

        void Update(Post post, User user, int id);

        void Delete(int id, User user);

        List<Post> Filter(PostFitlerParameters fitlerParameters);

        List<Post> GetNewest();

        List<Post> GetMostCommented();

        List<Post> GetAllPostsByUser(User user);

        //void AddLike(int postId, User user);

        //List<Post> GetMostLiked();
    }
}
