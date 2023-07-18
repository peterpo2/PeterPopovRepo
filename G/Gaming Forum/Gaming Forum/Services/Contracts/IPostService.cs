using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;

namespace Gaming_Forum.Services.Contracts
{
    public interface IPostService
    {
        Post CreatePost(PostDto postDto, User user);
        bool DeletePost(int postId);
        Post GetPostById(int postId);
        List<Post> GetAllPosts();
        public Post LikePost(int postId, User user);
        public Post DislikePost(int postId, User user);
        Post UpdatePost(int postId, Post post, User user);
        List<Comment> GetCommentsByPost(int postId);
        Comment GetCommentFromPost(int postId, int commentId);
        void DeleteAllPostComments(int postId);
        int CreateComment(int postId, CommentResponseDto commentDto, int userId);
        bool AddTagToPost(int postId, int tagId);
        PaginatedList<Post> FilterBy(SearchQueryParameters searchQueryParameters);
        List<Post> SearchPosts(string query);

    }
}