using Gaming_Forum.Models;

namespace Gaming_Forum.Repository.Contracts
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();

        Post GetById(int id);

        Post GetByTitle(string title);

        List<Post> GetByUser(string username);
        
        List<Post> FilterBy(PostQueryParameters filterParameters);

        Post Create(Post post);

        Post Update (int id, Post post);

        Post Delete(int id);

        List<Comment> GetCommentsByPost(int postId);

        Comment GetCommentFromPost(int postId, int commentId);

        void DeleteAllCommentsForPost(int postId);

    }
}
