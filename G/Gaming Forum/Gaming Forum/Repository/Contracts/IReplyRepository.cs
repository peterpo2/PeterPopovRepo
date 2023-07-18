using Gaming_Forum.Models;

namespace Gaming_Forum.Repository.Contracts
{
    public interface IReplyRepository
    {
        Reply Create(Reply reply);
        bool Delete(int id);
        Reply Update(Reply reply);
        Reply GetById(int id);
        List<Reply> GetRepliesByComment(int commentId);
        List<Reply> SearchReplies(string query);

    }
}
