using System;
using Gaming_Forum.Exeptions;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Repository;
using Gaming_Forum.Repository.Contracts;
using Gaming_Forum.Services.Contracts;

namespace Gaming_Forum.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public int CreateComment(int postId, CommentResponseDto commentDto, int userId)
        {
            var post = _postRepository.GetById(postId);

            var comment = new Comment
            {
                UserId = userId,
                Content = commentDto.Content,
                DateCreated = DateTime.Now,
                IsDeleted = false
            };

            post.Comments.Add(comment);
            _postRepository.Update(post.Id, post);

            return comment.Id;
        }

        public Post CreatePost(PostDto postDto, User user)
        {
            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                Comments = new List<Comment>(),
                Replies = new List<Post>(),
                Tags = new List<Tag>(),
                Likes = new List<Like>(),
                IsDeleted = false
            };

            var createdPost = _postRepository.Create(post);
            return createdPost;
        }


        public bool DeletePost(int postId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
                return false;

            var deletedPost = _postRepository.Delete(post.Id);
            return deletedPost != null;
        }


        public Post GetPostById(int postId)
        {
            var post = _postRepository.GetById(postId);

            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id={postId} does not exist");
            }

            return post;
        }

        public List<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }


        public bool LikePost(int postId, User user)
        {
            var post = _postRepository.GetById(postId);

            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id={postId} does not exist");
            }

            _postRepository.Update(post.Id, post);

            return true;
        }

        public Post UpdatePost(int postId, Post updatedPost, User user)
        {
            var post = _postRepository.GetById(postId);

            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id={postId} does not exist");
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;

            _postRepository.Update(post.Id, post);

            return post;
        }

        public List<Comment> GetCommentsByPost(int postId)
        {
            return _postRepository.GetCommentsByPost(postId);
        }

        public Comment GetCommentFromPost(int postId, int commentId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id={postId} does not exist");
            }

            return post.Comments.FirstOrDefault(c => c.Id == commentId);
        }

        public void DeleteAllPostComments(int postId)
        {
            _postRepository.DeleteAllCommentsForPost(postId);
        }

        public List<Post> FilterPosts(PostQueryParameters filterParameters)
        {
            return _postRepository.FilterBy(filterParameters);
        }
    }
}
