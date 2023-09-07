using ForumManagementSystem.data;
using ForumManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumManagementSystem.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly ApplicationContext context;

        public CommentsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Create(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            return GetComments().ToList();
        }

        public List<Comment> GetAllCommentsByUser(User user)
        {
            return GetComments().Where(c => c.Author == user).ToList();
        }

        public User GetAuthorOfComment(int id)
        {
            return null;
        }

        public Comment GetById(int id)
        {
            return GetComments().FirstOrDefault(c => c.Id == id);
        }

        public Post GetComment(int id)
        {
            return null;
        }

        public void Update(Comment comment)
        {
            var commentToUpdate = GetById(comment.Id);

            commentToUpdate.Content = comment.Content;

            context.SaveChanges();
        }

        private IQueryable<Comment> GetComments()
        {
            return context.Comments.Include(c => c.Author);
        }
    }
}
