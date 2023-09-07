using ForumManagementSystem.Models;

namespace ForumManagementSystem.Repositories
{
    // TODO Move all Interfaces in a new package
    public interface ICommentsRepository
    {
        List<Comment> GetAll();

        List<Comment> GetAllCommentsByUser(User user);

        Comment GetById(int id);

        void Create(Comment comment);

        void Update(Comment comment);

        void Delete(Comment comment);

        User GetAuthorOfComment(int id);

        Post GetComment(int id);
    }
}
