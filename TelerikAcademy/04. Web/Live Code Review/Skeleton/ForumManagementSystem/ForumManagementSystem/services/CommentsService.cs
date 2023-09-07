using ForumManagementSystem.Models;
using ForumManagementSystem.Repositories;

namespace ForumManagementSystem.services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository repository;

        public CommentsService(ICommentsRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Comment comment, User user)
        {
            repository.Create(comment);
        }

        public void Delete(Comment comment)
        {
            repository.Delete(comment);
        }

        public List<Comment> GetAll()
        {
            return repository.GetAll();
        }

        public List<Comment> GetAllCommentsByUser(User user)
        {
            return repository.GetAllCommentsByUser(user);
        }

        public List<Comment> GetAllCommentsForAPost(int postId)
        {
            List<Comment> result = repository.GetAll();
            result = result.Where(comment => comment.Post.Id == postId).ToList();
            return result;
        }

        public User GetAuthorOfComment(int id)
        {
            return repository.GetAuthorOfComment(id);
        }

        public Comment GetById(int id)
        {
            return repository.GetById(id);
        }

        public Post GetCommentPost(int id)
        {
            return repository.GetComment(id);
        }

        public void Update(Comment comment, int id)
        {
            //      if (existingComment.getId() == comment.getId()) {
            //          duplicateExists = false;
            //      }
            //  } catch (EntityNotFoundException e) {
            //      duplicateExists = false;
            //  }
            //
            //  if (duplicateExists) {
            //      throw new IllegalArgumentException();
            //  }
            //   comment.setId(commentId);
            repository.Update(comment);
        }
    }
}
