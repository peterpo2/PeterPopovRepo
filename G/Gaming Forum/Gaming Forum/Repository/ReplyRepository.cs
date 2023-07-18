using Gaming_Forum.Data;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Gaming_Forum.Repository
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly ApplicationContext context;

        public ReplyRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Reply Create(Reply reply)
        {
            reply.DateCreated = DateTime.Now;
            var createdReply = context.Replies.Add(reply);
            context.SaveChanges();
            return createdReply.Entity;
        }

        public bool Delete(int id)
        {
            var replyToDelete = GetById(id);
            replyToDelete.IsDeleted = true;
            context.Update(replyToDelete);
            context.SaveChanges();
            return true;
        }

        public Reply Update(Reply reply)
        {
            var updatedReply = context.Update(reply);
            context.SaveChanges();
            return updatedReply.Entity;
        }

        public Reply GetById(int id)
        {
            var reply = context.Replies
                .Include(r => r.User)
                .Include(r => r.Likes)
                    .ThenInclude(l => l.User)
                .FirstOrDefault(r => r.Id == id);

            if (reply == null || reply.IsDeleted)
            {
                throw new EntityNotFoundException($"Reply with id={id} not found.");
            }

            return reply;
        }

        public List<Reply> GetRepliesByComment(int commentId)
        {
            return context.Replies.Include(r => r.User)
                                  .Where(r => r.CommentId == commentId && !r.IsDeleted)
                                  .ToList();
        }

        public List<Reply> SearchReplies(string query)
        {
            return context.Replies
                .Include(r => r.User)
                .Where(r => EF.Functions.Like(r.Content, $"%{query}%"))
                .ToList();
        }
    }
}
