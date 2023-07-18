using Gaming_Forum.Models;
using Gaming_Forum.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchApiController : ControllerBase
    {
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IReplyRepository replyRepository;

        public SearchApiController(IPostRepository postRepository, ICommentRepository commentRepository, IReplyRepository replyRepository)
        {
            this.postRepository = postRepository;
            this.commentRepository = commentRepository;
            this.replyRepository = replyRepository;
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var searchResults = new List<SearchResult>();

            // Search in posts
            var matchingPosts = postRepository.SearchPosts(query);
            searchResults.AddRange(matchingPosts.Select(p => new SearchResult { EntityType = "Post", Title = p.Title, Content = p.Content }));

            // Search in comments
            var matchingComments = commentRepository.SearchComments(query);
            searchResults.AddRange(matchingComments.Select(c => new SearchResult { EntityType = "Comment", Title = null, Content = c.Content }));

            // Search in replies
            var matchingReplies = replyRepository.SearchReplies(query);
            searchResults.AddRange(matchingReplies.Select(r => new SearchResult { EntityType = "Reply", Title = null, Content = r.Content }));

            return Ok(searchResults);
        }

    }
}
