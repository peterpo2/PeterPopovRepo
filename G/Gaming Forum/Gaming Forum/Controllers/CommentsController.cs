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
    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly AuthManager authManager;
        private readonly IMapper mapper;
        private readonly IPostService postService;

        public CommentsController(ICommentService commentService, AuthManager authManager, IMapper mapper, IPostService postService)
        {
            this.commentService = commentService;
            this.authManager = authManager;
            this.mapper = mapper;
            this.postService = postService;
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
                var comment = this.commentService.GetById(id);
                foreach (var like in comment.Likes) 
                {
                    if(like.UserId == this.authManager.CurrentUser.Id && like.IsDeleted is not true)
                    {
                        this.commentService.DisslikeComment(id, this.authManager.CurrentUser);

                        return this.RedirectToAction("Details", "Posts", new { id = comment.PostId });
                    }
                }
                this.commentService.LikeComment(id, this.authManager.CurrentUser);

                return this.RedirectToAction("Details", "Posts", new { id = comment.PostId });

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

            var comment = new CommentRequestDto();

            return this.View(comment);
        }

        [HttpPost]
        public IActionResult Create([FromRoute] int id, CommentRequestDto comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(comment);
            }            

            var user = this.authManager.CurrentUser;
            _ = this.commentService.CreateComment(id, comment, user);

            return this.RedirectToAction("Details", "Posts", new { id });
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
				var comment = this.commentService.GetById(id);

				if (comment.UserId != this.authManager.CurrentUser.Id && !this.authManager.CurrentUser.IsAdmin)
				{
					this.Response.StatusCode = StatusCodes.Status403Forbidden;
					this.ViewData["ErrorMessage"] = $"You cannot edit this post since your are not the author.";

					return this.View("Error");
				}

				return this.View(mapper.Map<CommentRequestDto>(comment));
			}
			catch (EntityNotFoundException ex)
			{
				this.Response.StatusCode = StatusCodes.Status404NotFound;
				this.ViewData["ErrorMessage"] = ex.Message;

				return this.View("Error");
			}
		}

		[HttpPost]
		public IActionResult Edit([FromRoute] int id, CommentRequestDto comment)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(comment);
			}

			try
			{
				var user = this.authManager.CurrentUser;
				var updatedComment = this.commentService.UpdateComment(id, mapper.Map<Comment>(comment), user);

				return this.RedirectToAction("Details", "Posts", new { id = updatedComment.PostId});
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

                var comment = this.commentService.GetById(id);

                return this.View(comment);
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
                var comment = this.commentService.GetById(id);
                if (comment.User.Id != this.authManager.CurrentUser.Id && !this.authManager.CurrentUser.IsAdmin)
                {
                    throw new UnauthorizedOperationException("Only the creator of the comment or an admin can delete this comment.");
                }
                this.commentService.DeleteComment(id, this.authManager.CurrentUser);

                return this.RedirectToAction("Details", "Posts", new { id = comment.PostId });
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
    }
}
