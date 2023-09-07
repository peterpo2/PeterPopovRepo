using Gaming_Forum.Data;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Gaming_Forum.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationContext context;

        public PostRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Post> GetAllPosts()
        {
            return context.Posts 
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ToList();
        }

        public Post GetById(int id)
        {
            return context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id)
                ?? throw new EntityNotFoundException($"Post with id={id} not found.");
        }

        public Post GetByTitle(string title)
        {
            return context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Title == title)
                ?? throw new EntityNotFoundException($"Post with title '{title}' not found.");
        }

        public List<Post> GetByUser(string username)
        {
            return context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .Where(p => p.User.Username == username)
                .ToList();
        }

        public List<Post> FilterBy(PostQueryParameters filterParameters)
        {
            var query = context.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(filterParameters.Title))
            {
                query = query.Where(p => p.Title.Contains(filterParameters.Title));
            }

            if (!string.IsNullOrEmpty(filterParameters.User))
            {
                query = query.Where(p => p.User.Username == filterParameters.User);
            }

            if (!string.IsNullOrEmpty(filterParameters.Content))
            {
                query = query.Where(p => p.Content.Contains(filterParameters.Content));
            }

            if (filterParameters.Tags != null && filterParameters.Tags.Count > 0)
            {
                query = query.Where(p => p.Tags.Any(t => filterParameters.Tags.Contains(t.Value)));
            }

            if (filterParameters.SortByLikesDescending)
            {
                if (filterParameters.SortByLikesAscending)
                {
                    query = query.OrderBy(p => p.Likes.Count);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Likes.Count);
                }
            }


            return query.ToList();
        }

        public Post Create(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }

        public Post Update(int id, Post post)
        {
            var existingPost = GetById(id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
                existingPost.Tags = post.Tags;
                context.SaveChanges();
            }
            return existingPost;
        }

        public Post Delete(int id)
        {
            var postToDelete = GetById(id);
            if (postToDelete != null)
            {
                context.Posts.Remove(postToDelete);
                context.SaveChanges();
            }
            return postToDelete;
        }

        public List<Comment> GetCommentsByPost(int postId)
        {
            return context.Comments.Where(c => c.PostId == postId).ToList();
        }

        public Comment GetCommentFromPost(int postId, int commentId)
        {
            return context.Comments.FirstOrDefault(c => c.PostId == postId && c.Id == commentId);
        }

        public void DeleteAllCommentsForPost(int postId)
        {
            var commentsToDelete = context.Comments.Where(c => c.PostId == postId).ToList();
            context.Comments.RemoveRange(commentsToDelete);
            context.SaveChanges();
        }
    }
}