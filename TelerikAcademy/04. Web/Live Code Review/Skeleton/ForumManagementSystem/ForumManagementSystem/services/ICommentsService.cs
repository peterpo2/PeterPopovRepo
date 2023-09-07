using ForumManagementSystem.Models;

namespace ForumManagementSystem.services
{
    public interface ICommentsService
    {
        List<Comment> GetAll();

        List<Comment> GetAllCommentsForAPost(int postId);

        Comment GetById(int id);

        void Create(Comment comment, User user);

        void Update(Comment comment, int id);

        void Delete(Comment comment);

        List<Comment> GetAllCommentsByUser(User user);

        User GetAuthorOfComment(int id);

        Post GetCommentPost(int id);
    }
}
