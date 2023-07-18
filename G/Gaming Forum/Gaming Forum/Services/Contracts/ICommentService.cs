using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Repository;

namespace Gaming_Forum.Services.Contracts
{
    public interface ICommentService
    {
        Comment CreateComment(int postId, CommentRequestDto commentDto, User user);
        bool DeleteComment(int commentId, User user);
        Comment GetById(int commentId);
        List<Comment> GetAll();
        Comment UpdateComment(int commentId, Comment Comment, User user);
        Comment LikeComment(int commentId, User user);
        Comment DisslikeComment(int id, User user);
                
    }
}