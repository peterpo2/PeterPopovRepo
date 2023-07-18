using AutoMapper;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Helpers;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Models.ViewModels;
using Gaming_Forum.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Forum.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly AuthManager authManager;
        private readonly IMapper mapper;
        private readonly ITagService tagService;

        public PostsController(IPostService postService, AuthManager authManager, IMapper mapper, ITagService tagService)
        {
            this.postService = postService;
            this.authManager = authManager;
            this.mapper = mapper;
            this.tagService = tagService;
        }

        [HttpGet]
        public IActionResult Index(SearchQueryParameters searchQueryParameters, string sortBy, string tagValue)
        {
            searchQueryParameters.SortBy = sortBy;
            searchQueryParameters.TagValue = tagValue;

            var posts = this.postService.FilterBy(searchQueryParameters);

            return this.View(posts);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            try
            {
                var post = this.postService.GetPostById(id);

                return this.View(post);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (this.authManager.CurrentUser == null)
            {
                return this.RedirectToAction("Login", "Users");
            }

            var post = new PostViewModel();

            return this.View(post);
        }

        [HttpPost]
        public IActionResult Create(PostViewModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(post);
            }

            var user = this.authManager.CurrentUser;
            var createdPost = this.postService.CreatePost(mapper.Map<PostDto>(post), user);

            return this.RedirectToAction("Details", "Posts", new { id = createdPost.Id });
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            if (this.authManager.CurrentUser == null)
            {
                return this.RedirectToAction(actionName: "Login", controllerName: "Users");
            }

            try
            {
                var post = this.postService.GetPostById(id);

                if (post.UserId != this.authManager.CurrentUser.Id && !this.authManager.CurrentUser.IsAdmin)
                {
                    this.Response.StatusCode = StatusCodes.Status403Forbidden;
                    this.ViewData["ErrorMessage"] = $"You cannot edit this post since your are not the author.";

                    return this.View("Error");
                }

                return this.View(mapper.Map<PostViewModel>(post));
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, PostViewModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(post);
            }

            try
            {
                var user = this.authManager.CurrentUser;
                var updatedPost = this.postService.UpdatePost(id, mapper.Map<Post>(post), user);

                return this.RedirectToAction("Index", "Posts");
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status403Forbidden;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (this.authManager.CurrentUser == null)
                {
                    return this.RedirectToAction(actionName: "Login", controllerName: "Users");
                }

                var post = this.postService.GetPostById(id);

                return this.View(post);
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            try
            {
                var post = this.postService.GetPostById(id);
                if (post.User.Id != this.authManager.CurrentUser.Id && !this.authManager.CurrentUser.IsAdmin)
                {
                    throw new UnauthorizedOperationException("Only the creator of the post or an admin can delete this post.");
                }
                this.postService.DeletePost(id);

                return this.RedirectToAction("Index", "Posts");
            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
            catch (UnauthorizedOperationException ex)
            {
                this.Response.StatusCode = StatusCodes.Status401Unauthorized;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }
        [HttpGet]
        public IActionResult Like([FromRoute] int id)
        {
            if (this.authManager.CurrentUser == null)
            {
                return this.RedirectToAction(actionName: "Login", controllerName: "Users");
            }

            try
            {
                var post = this.postService.GetPostById(id);
                foreach (var like in post.Likes)
                {
                    if (like.UserId == this.authManager.CurrentUser.Id && like.IsDeleted is not true)
                    {
                        this.postService.DislikePost(id, this.authManager.CurrentUser);

                        return this.RedirectToAction("Index", "Posts");
                    }
                }
                this.postService.LikePost(id, this.authManager.CurrentUser);

                return this.RedirectToAction("Index", "Posts");

            }
            catch (EntityNotFoundException ex)
            {
                this.Response.StatusCode = StatusCodes.Status404NotFound;
                this.ViewData["ErrorMessage"] = ex.Message;

                return this.View("Error");
            }
        }
        [HttpGet]
        public IActionResult AddTag()
        {
            if (this.authManager.CurrentUser == null)
            {
                return this.RedirectToAction("Login", "Users");
            }

            var tag = new TagDto();

            return this.View(tag);
        }

        [HttpPost]
        public IActionResult AddTag([FromRoute] int id, TagDto tag)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(tag);
            }
            var createdTag = this.tagService.CreateTag(tag);
            var user = this.authManager.CurrentUser;
            _ = this.postService.AddTagToPost(id, createdTag.Id);

            return this.RedirectToAction("Details", "Posts", new { id });
        }
    }
}
