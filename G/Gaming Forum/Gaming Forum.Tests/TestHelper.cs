using Gaming_Forum.Models.Dto;
using Gaming_Forum.Models;

public class TestHelper
{
	public static Comment GetTestComment()
	{
		return new Comment
		{
			Id = 1,
			UserId = 1,
			User = new User { Id = 1, Username = "testuser" },
			PostId = 1,
			Post = new Post { Id = 1, Title = "Test Post" },
			Content = "Test Comment",
			DateCreated = DateTime.UtcNow,
			Replies = new List<Reply>(),
			Likes = new List<Like>(),
			IsDeleted = false
		};
	}
	public static Post GetTestPost()
	{
		return new Post()
		{
			Id = 1,
			UserId = 1,
			User = new User
			{
				Id = 1,
				Username = "testuser"
			},
			Title = "Test Post",
			Content = "Test Content",
			DateCreated = DateTime.UtcNow,
			Comments = new List<Comment>(),
			Replies = new List<Reply>(),
			Tags = new List<Tag>(),
			Likes = new List<Like>(),
			IsDeleted = false
		};
	}

	public static PostDto GetTestPostDto()
	{
		return new PostDto()
		{
			Title = "Test Post",
			Content = "Test Content"
		};
	}

	public static PostResponseDto GetTestPostResponseDto()
	{
		return new PostResponseDto()
		{
			User = new User
			{
				Id = 1,
				Username = "testuser"
			},
			Title = "Test Post",
			Content = "Test Content",
			DateCreated = DateTime.UtcNow,
			Comments = new List<CommentResponseDto>(),
			Replies = new List<ReplyResponseDto>(),
			Tags = new List<string>(),
			Likes = 0
		};
	}

	public static PostUserResponseDto GetTestPostUserResponseDto()
	{
		return new PostUserResponseDto()
		{
			Title = "Test Post",
			Content = "Test Content",
			DateCreated = DateTime.UtcNow,
			Comments = new List<CommentResponseDto>(),
			Replies = new List<ReplyResponseDto>(),
			Likes = 0
		};
	}
}
