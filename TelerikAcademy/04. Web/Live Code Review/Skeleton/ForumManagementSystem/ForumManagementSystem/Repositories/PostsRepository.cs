using ForumManagementSystem.data;
using ForumManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumManagementSystem.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly ApplicationContext context;

        public PostsRepository(ApplicationContext context)
        {
            this.context = context;
        }

        // TODO
        public void Create(Post post, User author)
        {
            post.Author = author;
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var postToDelete = GetByPostId(id);

            context.Posts.Remove(postToDelete);
            context.SaveChanges();
        }

        public List<Post> Filter(PostFitlerParameters fitlerParameters)
        {
            IQueryable<Post> result = GetPosts();

            result = FilterByTitle(result, fitlerParameters.Title);
            result = FilterByContent(result, fitlerParameters.Content);
           
            return result.ToList();
        }

        public List<Post> GetAll()
        {
            return GetPosts().ToList();
        }

        public List<Post> GetAllPostsByUser(User user)
        {
            return GetPosts().Where(post => post.Author == user).ToList();
        }

        public Post GetByPostId(int id)
        {
            return GetPosts().FirstOrDefault(post => post.Id == id);
        }

        public Post GetByTitle(string title)
        {
            return GetPosts().FirstOrDefault(p => p.Title == title);
        }

        public void Update(Post post)
        {
            var postToUpdate = GetByPostId(post.Id);

            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;

            context.SaveChanges();
        }

        private static IQueryable<Post> FilterByTitle(IQueryable<Post> posts, string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                return posts.Where(post => post.Title.Contains(title));
            }
            return posts;
        }

        private static IQueryable<Post> FilterByContent(IQueryable<Post> posts, string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                return posts.Where(post => post.Content.Contains(content));
            }
            return posts;
        }

        private static IQueryable<Post> SortBy(IQueryable<Post> posts, string sortCriteria)
        {
            switch (sortCriteria)
            {
                case "comments":
                    return posts.OrderBy(post => post.Comments.Count);
                case "date":
                    return posts.OrderBy(post => post.Date);
                default:
                    return posts;
            }
        }

        private static IQueryable<Post> Order(IQueryable<Post> posts, string sortOrder)
        {
            return (sortOrder == "desc") ? posts.Reverse() : posts;
        }

        private IQueryable<Post> GetPosts()
        {
            return context.Posts
                    .Include(post => post.Comments)
                    .Include(post => post.Tags)
                    .Include(post => post.Author);
        }
    }
}
