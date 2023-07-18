using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Repository.Contracts;
using Gaming_Forum.Services;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Tests
{
	[TestClass]
	public class PostServiceTests
	{
		private readonly IPostService postService;
		private readonly Mock<IPostRepository> postRepositoryMock;
		private readonly Mock<ITagRepository> tagRepositoryMock;

		public PostServiceTests()
		{
			postRepositoryMock = new Mock<IPostRepository>();
			tagRepositoryMock = new Mock<ITagRepository>();
			postService = new PostService(postRepositoryMock.Object, tagRepositoryMock.Object);
		}
		[TestMethod]
		public void CreatePost_ValidPostDto_ReturnsCreatedPost()
		{
			// Arrange
			var postDto = new PostDto
			{
				Title = "Test Post",
				Content = "Test Content"
			};

			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};

			var createdPost = TestHelper.GetTestPost();

			postRepositoryMock.Setup(r => r.Create(It.IsAny<Post>())).Returns(createdPost);

			// Act
			var result = postService.CreatePost(postDto, user);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(createdPost.Title, result.Title);
			Assert.AreEqual(createdPost.Content, result.Content);
			// Add more assertions as needed
		}
		[TestMethod]
		public void DeletePost_ExistingPost_ReturnsTrue()
		{
			// Arrange
			int postId = 1;
			var existingPost = TestHelper.GetTestPost();
			existingPost.IsDeleted = false;

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(existingPost);
			postRepositoryMock.Setup(r => r.Update(It.IsAny<Post>())).Returns((Post post) => post);

			// Act
			bool result = postService.DeletePost(postId);

			// Assert
			Assert.IsTrue(result);
			Assert.IsTrue(existingPost.IsDeleted);
		}
		[TestMethod]
		public void DeletePost_NonExistingPost_ReturnsFalse()
		{
			// Arrange
			int postId = 1;
			Post existingPost = null;

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(existingPost);

			// Act
			bool result = postService.DeletePost(postId);

			// Assert
			Assert.IsFalse(result);
			postRepositoryMock.Verify(r => r.Update(It.IsAny<Post>()), Times.Never);
		}
		[TestMethod]
		public void GetPostById_ExistingPost_ReturnsPost()
		{
			// Arrange
			int postId = 1;
			var existingPost = TestHelper.GetTestPost();

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(existingPost);

			// Act
			var result = postService.GetPostById(postId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(existingPost, result);
		}
		[TestMethod]
		public void GetPostById_NonExistingPost_ThrowsEntityNotFoundException()
		{
			// Arrange
			int postId = 1;
			Post existingPost = null;

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(existingPost);

			// Act and Assert
			Assert.ThrowsException<EntityNotFoundException>(() => postService.GetPostById(postId));
		}
		[TestMethod]
		public void GetAllPosts_ReturnsAllPosts()
		{
			// Arrange
			var posts = new List<Post>
	{
		TestHelper.GetTestPost(),
		TestHelper.GetTestPost(),
		TestHelper.GetTestPost()
	};

			postRepositoryMock.Setup(r => r.GetAllPosts()).Returns(posts);

			// Act
			var result = postService.GetAllPosts();

			// Assert
			Assert.AreEqual(posts.Count, result.Count);
			foreach (var post in posts)
			{
				Assert.IsTrue(result.Contains(post));
			}
		}
		[TestMethod]
		public void LikePost_ValidPostIdAndUser_LikesPost()
		{
			// Arrange
			int postId = 1;
			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};
			var post = TestHelper.GetTestPost();
			post.Likes = new List<Like>();

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);
			postRepositoryMock.Setup(r => r.Update(It.IsAny<Post>())).Returns((Post updatedPost) => updatedPost);

			// Act
			var result = postService.LikePost(postId, user);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Likes.Count);
			Assert.AreEqual(user, result.Likes[0].User);
			Assert.AreEqual(post, result.Likes[0].Post);
		}
		[TestMethod]
		public void DislikePost_ValidPostIdAndUser_DislikesPost()
		{
			// Arrange
			int postId = 1;
			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};
			var post = TestHelper.GetTestPost();
			var like = new Like
			{
				User = user,
				Post = post
			};
			post.Likes = new List<Like> { like };

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);
			postRepositoryMock.Setup(r => r.Update(It.IsAny<Post>())).Returns((Post updatedPost) => updatedPost);

			// Act
			var result = postService.DislikePost(postId, user);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(1, result.Likes.Count);
			Assert.IsTrue(result.Likes[0].IsDeleted);
		}
		[TestMethod]
		public void UpdatePost_ValidPostIdAndUser_UpdatesPost()
		{
			// Arrange
			int postId = 1;
			var user = new User
			{
				Id = 1,
				Username = "testuser"
			};
			var post = TestHelper.GetTestPost();
			var updatedPost = new Post
			{
				Id = postId,
				Title = "Updated Title",
				Content = "Updated Content"
			};

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);
			postRepositoryMock.Setup(r => r.Update(It.IsAny<Post>())).Returns((Post updated) => updated);

			// Act
			var result = postService.UpdatePost(postId, updatedPost, user);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(updatedPost.Title, result.Title);
			Assert.AreEqual(updatedPost.Content, result.Content);
			// Add more assertions if necessary
		}
		[TestMethod]
		public void DeletePost_ValidPostId_DeletesPost()
		{
			// Arrange
			int postId = 1;
			var post = TestHelper.GetTestPost();

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);
			postRepositoryMock.Setup(r => r.Update(It.IsAny<Post>())).Returns((Post updatedPost) => updatedPost);

			// Act
			var result = postService.DeletePost(postId);

			// Assert
			Assert.IsTrue(result);
			Assert.IsTrue(post.IsDeleted);
		}
		[TestMethod]
		public void GetPostById_ExistingPostId_ReturnsPost()
		{
			// Arrange
			int postId = 1;
			var post = TestHelper.GetTestPost();

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);

			// Act
			var result = postService.GetPostById(postId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(postId, result.Id);
			Assert.AreEqual(post.Title, result.Title);
			Assert.AreEqual(post.Content, result.Content);
			// Add more assertions if necessary
		}
		[TestMethod]
		[ExpectedException(typeof(EntityNotFoundException))]
		public void GetPostById_NonexistentPostId_ThrowsEntityNotFoundException()
		{
			// Arrange
			int postId = 1;

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns((Post)null);

			// Act
			var result = postService.GetPostById(postId);

			// Assert
			// Exception is expected
		}
		[TestMethod]
		public void GetCommentsByPost_ExistingPostId_ReturnsComments()
		{
			// Arrange
			int postId = 1;
			var post = TestHelper.GetTestPost();
			var comments = new List<Comment>
	{
		new Comment { Id = 1, Content = "Comment 1" },
		new Comment { Id = 2, Content = "Comment 2" },
		new Comment { Id = 3, Content = "Comment 3" }
	};

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);
			postRepositoryMock.Setup(r => r.GetCommentsByPost(postId)).Returns(comments);

			// Act
			var result = postService.GetCommentsByPost(postId);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(comments.Count, result.Count);
			foreach (var comment in comments)
			{
				Assert.IsTrue(result.Contains(comment));
			}
		}
		[TestMethod]
		[ExpectedException(typeof(DuplicateEntityException))]
		public void LikePost_DuplicateLikeByUser_ThrowsDuplicateEntityException()
		{
			// Arrange
			int postId = 1;
			var post = TestHelper.GetTestPost();
			var user = new User { Id = 1, Username = "testuser" };
			var like = new Like { User = user, Post = post };

			post.Likes.Add(like);
			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);

			// Act
			var result = postService.LikePost(postId, user);

			// Assert
			// Exception is expected
		}
		[TestMethod]
		[ExpectedException(typeof(UnauthorizedOperationException))]
		public void DislikePost_UserHasNotLikedPost_ThrowsUnauthorizedOperationException()
		{
			// Arrange
			int postId = 1;
			var post = TestHelper.GetTestPost();
			var user = new User { Id = 1, Username = "testuser" };

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns(post);

			// Act
			var result = postService.DislikePost(postId, user);

			// Assert
			// Exception is expected
		}
		[TestMethod]
		public void GetAllPosts_ReturnsListOfPosts()
		{
			// Arrange
			var posts = new List<Post>
	{
		new Post { Id = 1, Title = "Post 1" },
		new Post { Id = 2, Title = "Post 2" },
		new Post { Id = 3, Title = "Post 3" }
	};

			postRepositoryMock.Setup(r => r.GetAllPosts()).Returns(posts);

			// Act
			var result = postService.GetAllPosts();

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(posts.Count, result.Count);
			// Add more assertions as needed
		}
		[TestMethod]
		[ExpectedException(typeof(EntityNotFoundException))]
		public void GetPostById_NonExistingPostId_ThrowsEntityNotFoundException()
		{
			// Arrange
			int postId = 999;

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns((Post)null);

			// Act
			var result = postService.GetPostById(postId);

			// Assert
			// Exception is expected
		}
		[TestMethod]
		public void DeletePost_NonExistingPostId_ReturnsFalse()
		{
			// Arrange
			int postId = 999;

			postRepositoryMock.Setup(r => r.GetById(postId)).Returns((Post)null);

			// Act
			var result = postService.DeletePost(postId);

			// Assert
			Assert.IsFalse(result);
		}
	}
}