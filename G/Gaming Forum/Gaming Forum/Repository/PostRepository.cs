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
                    .ThenInclude(c => c.User)
                .Include(p => p.Likes)
                .ToList();
        }

        public Post GetById(int id)
        {
            return context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Likes)
                .Include(p => p.Tags)
                .Include(p => p.Likes)
                .SingleOrDefault(p => p.Id == id)
                ?? throw new EntityNotFoundException($"Post with id={id} not found.");
        }

        public Post GetByTitle(string title)
        {
            return context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Include(p => p.Likes)
                .SingleOrDefault(p => p.Title == title)
                ?? throw new EntityNotFoundException($"Post with title '{title}' not found.");
        }

        public List<Post> GetByUser(string username)
        {
            return context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                .Include(p => p.Likes)
                .Where(p => p.User.Username == username)
                .ToList();
        }

        
        public Post Create(Post post)
        {
            post.DateCreated = DateTime.Now;
            context.Posts.Add(post);
            context.SaveChanges();
            return post;
        }

        public Post Update(Post post)
        {
            var updatedPost = context.Update(post);
            context.SaveChanges();

            return updatedPost.Entity;
        }

        public Post Delete(int id)
        {
            var postToDelete = GetById(id);
            if (postToDelete != null)
            {
                postToDelete.IsDeleted = true;
                context.Update(postToDelete);
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

        public PaginatedList<Post> FilterBy(SearchQueryParameters searchQueryParameters)
        {
            var query = context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
                .ThenInclude(c => c.User)
            .Include(p => p.Likes)
            .AsQueryable();

            if (!string.IsNullOrEmpty(searchQueryParameters.Title))
            {
                query = query.Where(p => p.Title.Contains(searchQueryParameters.Title));
            }

            if (!string.IsNullOrEmpty(searchQueryParameters.User))
            {
                query = query.Where(p => p.User.Username == searchQueryParameters.User);
            }

            if (!string.IsNullOrEmpty(searchQueryParameters.Content))
            {
                query = query.Where(p => p.Content.Contains(searchQueryParameters.Content));
            }

            /*if (searchQueryParameters.Tags != null && searchQueryParameters.Tags.Count > 0)
            {
                query = query.Where(p => p.Tags.Any(t => searchQueryParameters.Tags.Contains(t.Value)));
            }*/
            
            int totalPages = (query.Count() + 1) / searchQueryParameters.PageSize;

            query = Paginate(query, searchQueryParameters.PageNumber, searchQueryParameters.PageSize);

            return new PaginatedList<Post>(query.ToList(), totalPages, searchQueryParameters.PageNumber);
        }

        public static IQueryable<Post> Paginate(IQueryable<Post> result, int pageNumber, int pageSize)
        {
            return result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        public List<Post> SearchPosts(string query)
        {
            return context.Posts
                .Include(p => p.User)
                .Where(p => EF.Functions.Like(p.Title, $"%{query}%") || EF.Functions.Like(p.Content, $"%{query}%"))
                .ToList();
        }

    }
}