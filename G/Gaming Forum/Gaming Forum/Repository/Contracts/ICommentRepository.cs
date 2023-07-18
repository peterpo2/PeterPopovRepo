using Gaming_Forum.Models;

namespace Gaming_Forum.Repository.Contracts
{
    public interface ICommentRepository
    {

        Comment GetById(int id);

        Comment Create(Comment comment);

        Comment Update(Comment comment);

        bool Delete(int id);
        List<Comment> GetAll();
        List<Comment> SearchComments(string query);
    }
}
