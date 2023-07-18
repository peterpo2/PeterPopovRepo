using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;

namespace Gaming_Forum.Services.Contracts
{
    public interface IReplyService
    {
        Reply CreateReply(int commentId, ReplyRequestDto replyDto, User user);
        bool DeleteReply(int id, User user);
        Reply UpdateReply(int id, Reply reply, User user);
        Reply GetReplyById(int id);
        List<Reply> GetRepliesByComment(int commentId);
        public Reply LikeReply(int replyId, User user);
        public Reply DislikeReply(int replyId, User user);
    }
}
