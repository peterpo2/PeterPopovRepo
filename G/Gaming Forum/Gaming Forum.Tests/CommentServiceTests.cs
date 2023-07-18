using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Repository.Contracts;
using Gaming_Forum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gaming_Forum.Tests.Services
{
	[TestClass]
	public class CommentServiceTests
	{
		private Mock<ICommentRepository> commentRepositoryMock;
		private CommentService commentService;

		[TestInitialize]
		public void Initialize()
		{
			commentRepositoryMock = new Mock<ICommentRepository>();
			commentService = new CommentService(commentRepositoryMock.Object);
		}

		[TestMethod]
		public void CreateComment_ValidData_ReturnsCreatedComment()
		{
			// Arrange
			int postId = 1;
			var commentDto = new CommentRequestDto
			{
				Content = "Test Comment"
			};

			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};

			var createdComment = new Comment
			{
				Id = 1,
				PostId = postId,
				Content = commentDto.Content,
				UserId = user.Id,
				DateCreated = DateTime.UtcNow,
				Replies = new List<Reply>(),
				Likes = new List<Like>(),
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.Create(It.IsAny<Comment>())).Returns(createdComment);

			// Act
			var result = commentService.CreateComment(postId, commentDto, user);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(createdComment.Id, result.Id);
			Assert.AreEqual(createdComment.PostId, result.PostId);
			Assert.AreEqual(createdComment.Content, result.Content);
			Assert.AreEqual(createdComment.UserId, result.UserId);
			Assert.AreEqual(createdComment.DateCreated, result.DateCreated);
			Assert.AreEqual(createdComment.Replies.Count, result.Replies.Count);
			Assert.AreEqual(createdComment.Likes.Count, result.Likes.Count);
			Assert.AreEqual(createdComment.IsDeleted, result.IsDeleted);
		}
		[TestMethod]
		public void GetById_ValidId_ReturnsComment()
		{
			// Arrange
			int commentId = 1;
			var comment = new Comment
			{
				Id = commentId,
				UserId = 1,
				User = new User(),
				PostId = 1,
				Post = new Post(),
				Content = "Test Comment",
				DateCreated = DateTime.UtcNow,
				Replies = new List<Reply>(),
				Likes = new List<Like>(),
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(comment);

			// Act
			var result = commentService.GetById(commentId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(comment.Id, result.Id);
			Assert.AreEqual(comment.UserId, result.UserId);
			Assert.AreEqual(comment.PostId, result.PostId);
			Assert.AreEqual(comment.Content, result.Content);
			Assert.AreEqual(comment.DateCreated, result.DateCreated);
			Assert.AreEqual(comment.Replies.Count, result.Replies.Count);
			Assert.AreEqual(comment.Likes.Count, result.Likes.Count);
			Assert.AreEqual(comment.IsDeleted, result.IsDeleted);
		}
		[TestMethod]
		public void UpdateComment_UnauthorizedUser_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			int commentId = 1;
			var updatedComment = new Comment
			{
				Content = "Updated Comment"
			};

			var user = new User
			{
				Id = 2, // Different user ID
				Username = "otheruser"
			};

			var existingComment = new Comment
			{
				Id = commentId,
				UserId = 1,
				User = new User(),
				PostId = 1,
				Post = new Post(),
				Content = "Test Comment",
				DateCreated = DateTime.UtcNow,
				Replies = new List<Reply>(),
				Likes = new List<Like>(),
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(existingComment);

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() => commentService.UpdateComment(commentId, updatedComment, user));
		}

		[TestMethod]
		public void DislikeComment_NoExistingLikes_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			int commentId = 1;
			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};

			var commentToDislike = new Comment
			{
				Id = commentId,
				UserId = 1,
				User = new User(),
				PostId = 1,
				Post = new Post(),
				Content = "Test Comment",
				DateCreated = DateTime.UtcNow,
				Replies = new List<Reply>(),
				Likes = new List<Like>(),
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(commentToDislike);

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() => commentService.DisslikeComment(commentId, user));
		}
		[TestMethod]
		public void DeleteComment_UnauthorizedUser_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			int commentId = 1;
			var user = new User
			{
				Id = 2, // Different user ID
				Username = "otheruser"
			};

			var existingComment = new Comment
			{
				Id = commentId,
				UserId = 1,
				User = new User(),
				PostId = 1,
				Post = new Post(),
				Content = "Test Comment",
				DateCreated = DateTime.UtcNow,
				Likes = new List<Like>(),
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(existingComment);

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() => commentService.DeleteComment(commentId, user));
		}
		[TestMethod]
		public void DisslikeComment_NoExistingLikes_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			int commentId = 1;
			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};

			var commentToDisslike = new Comment
			{
				Id = commentId,
				UserId = 2, // Different user ID
				User = new User(),
				PostId = 1,
				Post = new Post(),
				Content = "Test Comment",
				DateCreated = DateTime.UtcNow,
				Replies = new List<Reply>(),
				Likes = new List<Like>(),
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(commentToDisslike);

			// Act & Assert
			Assert.ThrowsException<UnauthorizedOperationException>(() => commentService.DisslikeComment(commentId, user));
		}
		[TestMethod]
		public void GetAll_ReturnsAllComments()
		{
			// Arrange
			var comments = new List<Comment>
	{
		new Comment { Id = 1 },
		new Comment { Id = 2 },
		new Comment { Id = 3 }
	};

			commentRepositoryMock.Setup(r => r.GetAll()).Returns(comments);

			// Act
			var result = commentService.GetAll();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(comments.Count, result.Count);
			Assert.IsTrue(comments.All(c => result.Any(r => r.Id == c.Id)));
		}
		[TestMethod]
		public void LikeComment_DuplicateLike_ThrowsDuplicateEntityException()
		{
			// Arrange
			int commentId = 1;
			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};

			var existingLike = new Like
			{
				Id = 1,
				CommentId = commentId,
				UserId = user.Id,
				User = user,
				IsDeleted = false
			};

			var commentToLike = new Comment
			{
				Id = commentId,
				UserId = 2,
				User = new User(),
				PostId = 1,
				Post = new Post(),
				Content = "Test Comment",
				DateCreated = DateTime.UtcNow,
				Likes = new List<Like> { existingLike },
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(commentToLike);

			// Act & Assert
			var exception = Assert.ThrowsException<DuplicateEntityException>(() => commentService.LikeComment(commentId, user));
			Assert.AreEqual("User already liked this comment.", exception.Message);
		}
		[TestMethod]
		public void DeleteComment_ValidData_ReturnsTrue()
		{
			// Arrange
			int commentId = 1;
			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};

			var existingComment = new Comment
			{
				Id = commentId,
				UserId = user.Id,
				User = user,
				PostId = 1,
				Post = new Post(),
				Content = "Test Comment",
				DateCreated = DateTime.UtcNow,
				Replies = new List<Reply>(),
				Likes = new List<Like>(),
				IsDeleted = false
			};

			commentRepositoryMock.Setup(r => r.GetById(commentId)).Returns(existingComment);
			commentRepositoryMock.Setup(r => r.Delete(commentId)).Returns(true);

			// Act
			var result = commentService.DeleteComment(commentId, user);

			// Assert
			Assert.IsTrue(result);
		}
	}
}
