using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Repository.Contracts;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Services
{
    public class CommentService : ICommentService
    {
        private const string ModifyCommentErrorMessage = "Only owner or admin can modify a comment.";
        private const string DuplicateLikeCommentErrorMessage = "User already liked this comment.";
        private const string DisslikeCommentErrorMessage = "User has not liked this comment.";

        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public Comment CreateComment(int postId, CommentRequestDto commentDto, User user)
        {
            var comment = new Comment
            {
                PostId = postId,
                Content = commentDto.Content,
                UserId = user.Id
            };

            var createdComment = commentRepository.Create(comment);
            return createdComment;
        }

        public bool DeleteComment(int id, User user)
        {
            var commentToDelete = commentRepository.GetById(id);
            if (!commentToDelete.User.Equals(user) && !user.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyCommentErrorMessage);
            }
            return commentRepository.Delete(id);
        }

        public Comment GetById(int id)
        {
            return commentRepository.GetById(id);
        }

        public Comment UpdateComment(int id, Comment comment, User user)
        {
            var commentToModify = commentRepository.GetById(id);
            if (!commentToModify.User.Equals(user) && !user.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyCommentErrorMessage);
            }
            commentToModify.Content = comment.Content;
            return commentRepository.Update(commentToModify);
        }
        public Comment LikeComment(int id, User user)
        {
            var commentToLike = commentRepository.GetById(id);
            foreach (var like in commentToLike.Likes)
            {
                if (like.UserId.Equals(user.Id) && like.IsDeleted is false)
                {
                    throw new DuplicateEntityException(DuplicateLikeCommentErrorMessage);
                }
            }
            commentToLike.Likes.Add(new Like { User = user, Comment = commentToLike });
            return commentRepository.Update(commentToLike);
        }
        public Comment DisslikeComment(int id, User user)
        {
            var commentToDisslike = commentRepository.GetById(id);
            if (commentToDisslike.Likes.Count() == 0)
            {
                throw new UnauthorizedOperationException(DisslikeCommentErrorMessage);
            }
            foreach (var like in commentToDisslike.Likes)
            {
                if (like.UserId.Equals(user.Id) && like.IsDeleted is false)
                {
                    like.IsDeleted = true;
                    return commentRepository.Update(commentToDisslike);
                }
            }
            throw new UnauthorizedOperationException(DisslikeCommentErrorMessage);
        }
        public List<Comment> GetAll()
        {
            return commentRepository.GetAll();
        }

    }
}
