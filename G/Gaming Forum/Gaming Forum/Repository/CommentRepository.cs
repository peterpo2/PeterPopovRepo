using Gaming_Forum.Data;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Gaming_Forum.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationContext context;

        public CommentRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Comment Create(Comment comment)
        {
            comment.DateCreated = DateTime.Now;
            var createdComment = context.Comments.Add(comment);
            context.SaveChanges();
            return createdComment.Entity;
        }

        public bool Delete(int id)
        {
            var commentToDelete = this.GetById(id);
            commentToDelete.IsDeleted = true;
            context.Update(commentToDelete);
            context.SaveChanges();
            return true;
        }
        public Comment Update(Comment comment)
        {
            var updatedComment = context.Update(comment);
            context.SaveChanges();

            return updatedComment.Entity;
        }
        public Comment GetById(int id)
        {
            var comment = this.context.Comments.Include(c => c.User)
                                               .Include(c => c.Likes)
                                                   .ThenInclude(l => l.User)
                                               .Include(c => c.Replies)
                                                   .ThenInclude(r => r.User)
                                               .Include(c => c.Post)
                                                   .ThenInclude(p => p.User)
                                               .FirstOrDefault(c => c.Id == id);
            if (comment == null || comment.IsDeleted)
            {
                throw new EntityNotFoundException($"Comment with id={id} not found.");
            }
            return comment;
        }
        public List<Comment> GetAll()
        {
            return this.context.Comments.Include(c => c.User)
                                        .Include(c => c.Likes)
                                        .Include(c => c.Replies)
                                            .ThenInclude(r => r.User)
                                        .Include(c => c.Post)
                                            .ThenInclude(p => p.User)
                                        .Where(c => c.IsDeleted == false)
                                        .ToList();
        }

        public List<Comment> SearchComments(string query)
        {
            return context.Comments
                .Include(c => c.User)
                .Where(c => EF.Functions.Like(c.Content, $"%{query}%"))
                .ToList();
        }

    }
}
