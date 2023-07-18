using System;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Repository;
using Gaming_Forum.Repository.Contracts;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Services
{
    public class ReplyService : IReplyService
    {
        private const string ModifyReplyErrorMessage = "Only owner or admin can modify a reply.";
        private const string DuplicateLikeReplyErrorMessage = "User already liked this reply.";
        private const string DislikeReplyErrorMessage = "User has not liked this reply.";

        private readonly IReplyRepository replyRepository;

        public ReplyService(IReplyRepository replyRepository)
        {
            this.replyRepository = replyRepository;
        }

        public Reply CreateReply(int commentId, ReplyRequestDto replyDto, User user)
        {
            var reply = new Reply
            {
                CommentId = commentId,
                Content = replyDto.Content,
                UserId = user.Id
            };

            var createdReply = replyRepository.Create(reply);
            return createdReply;
        }

        public bool DeleteReply(int id, User user)
        {
            var replyToDelete = replyRepository.GetById(id);

            if (!replyToDelete.User.Equals(user) && !user.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyReplyErrorMessage);
            }

            return replyRepository.Delete(id);
        }

        public Reply UpdateReply(int id, Reply reply, User user)
        {
            var replyToModify = replyRepository.GetById(id);

            if (!replyToModify.User.Equals(user) && !user.IsAdmin)
            {
                throw new UnauthorizedOperationException(ModifyReplyErrorMessage);
            }

            replyToModify.Content = reply.Content;

            return replyRepository.Update(replyToModify);
        }

        public Reply GetReplyById(int id)
        {
            return replyRepository.GetById(id);
        }

        public List<Reply> GetRepliesByComment(int commentId)
        {
            return replyRepository.GetRepliesByComment(commentId);
        }

        public Reply LikeReply(int replyId, User user)
        {
            var replyToLike = replyRepository.GetById(replyId);
            foreach (var like in replyToLike.Likes)
            {
                if (like.User.Equals(user) && !like.IsDeleted)
                {
                    throw new DuplicateEntityException(DuplicateLikeReplyErrorMessage);
                }
            }
            replyToLike.Likes.Add(new Like { User = user, Reply = replyToLike });
            return replyRepository.Update(replyToLike);
        }

        public Reply DislikeReply(int replyId, User user)
        {
            var replyToDislike = replyRepository.GetById(replyId);
            if (replyToDislike.Likes is null)
            {
                throw new UnauthorizedOperationException(DislikeReplyErrorMessage);
            }
            foreach (var like in replyToDislike.Likes)
            {
                if (like.User.Equals(user) && !like.IsDeleted)
                {
                    like.IsDeleted = true;
                    return replyRepository.Update(replyToDislike);
                }
            }
            throw new UnauthorizedOperationException(DislikeReplyErrorMessage);
        }
    }
}
