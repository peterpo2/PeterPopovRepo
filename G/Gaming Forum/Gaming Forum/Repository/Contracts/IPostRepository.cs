using Gaming_Forum.Models;

namespace Gaming_Forum.Repository.Contracts
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();

        Post GetById(int id);

        Post GetByTitle(string title);

        List<Post> GetByUser(string username);

        PaginatedList<Post> FilterBy(SearchQueryParameters searchQueryParameters);

        Post Create(Post post);

        Post Update(Post post);

        Post Delete(int id);

        List<Comment> GetCommentsByPost(int postId);

        Comment GetCommentFromPost(int postId, int commentId);

        void DeleteAllCommentsForPost(int postId);
        List<Post> SearchPosts(string query);


    }
}
