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
        private const string ModifyPostErrorMessage = "Only owner or admin can modify a post.";
        private const string DuplicateLikePostErrorMessage = "User already liked this post.";
        private const string DislikePostErrorMessage = "User has not liked this post.";

        private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;

        public PostService(IPostRepository postRepository, ITagRepository tagRepository)
        {
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
        }



        public Post CreatePost(PostDto postDto, User user)
        {
            var post = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                Comments = new List<Comment>(),
                Replies = new List<Reply>(),
                Tags = new List<Tag>(),
                Likes = new List<Like>(),
                IsDeleted = false,
                User = user
            };

            var createdPost = this.postRepository.Create(post);
            return createdPost;
        }


        public bool DeletePost(int postId)
        {
            var post = this.postRepository.GetById(postId);
            if (post == null)
                return false;

            post.IsDeleted = true;
            var deletedPost = this.postRepository.Update(post);
            return deletedPost != null;
        }


        public Post GetPostById(int postId)
        {
            var post = this.postRepository.GetById(postId);

            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id={postId} does not exist");
            }

            return post;
        }

        public List<Post> GetAllPosts()
        {
            return this.postRepository.GetAllPosts();
        }


        public Post LikePost(int postId, User user)
        {
            var postToLike = postRepository.GetById(postId);
            foreach (var like in postToLike.Likes)
            {
                if (like.User != null && like.User.Equals(user) && !like.IsDeleted)
                {
                    throw new DuplicateEntityException(DuplicateLikePostErrorMessage);
                }
            }

            var newLike = new Like { User = user, Post = postToLike };
            postToLike.Likes.Add(newLike);

            return postRepository.Update(postToLike);
        }


        public Post DislikePost(int postId, User user)
        {
            var postToDislike = postRepository.GetById(postId);
            if (postToDislike.Likes is null)
            {
                throw new UnauthorizedOperationException(DislikePostErrorMessage);
            }
            foreach (var like in postToDislike.Likes)
            {
                if (like.User.Equals(user) && !like.IsDeleted)
                {
                    like.IsDeleted = true;
                    return postRepository.Update(postToDislike);
                }
            }
            throw new UnauthorizedOperationException(DislikePostErrorMessage);
        }



        public Post UpdatePost(int postId, Post updatedPost, User user)
        {
            var post = this.postRepository.GetById(postId);

            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id={postId} does not exist");
            }

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;

            this.postRepository.Update(post);

            return post;
        }

        public List<Comment> GetCommentsByPost(int postId)
        {
            return this.postRepository.GetCommentsByPost(postId);
        }

        public Comment GetCommentFromPost(int postId, int commentId)
        {
            var post = this.postRepository.GetById(postId);
            if (post == null)
            {
                throw new EntityNotFoundException($"Post with id={postId} does not exist");
            }

            return post.Comments.FirstOrDefault(c => c.Id == commentId);
        }

        public void DeleteAllPostComments(int postId)
        {
            this.postRepository.DeleteAllCommentsForPost(postId);
        }

        public int CreateComment(int postId, CommentResponseDto commentDto, int userId)
        {
            var post = this.postRepository.GetById(postId);

            var comment = new Comment
            {
                UserId = userId,
                Content = commentDto.Content,
                DateCreated = DateTime.Now,
                IsDeleted = false
            };

            post.Comments.Add(comment);
            this.postRepository.Update(post);

            return comment.Id;
        }

        public bool AddTagToPost(int postId, int tagId)
        {
            var post = postRepository.GetById(postId);
            var tag = tagRepository.GetById(tagId);

            if (post == null || tag == null)
            {
                return false;
            }
            
            post.Tags.Add(tag);
            postRepository.Update(post);

            return true;
        }

        public PaginatedList<Post> FilterBy(SearchQueryParameters searchQueryParameters)
        {
            if (!string.IsNullOrEmpty(searchQueryParameters.Query))
            {
                var matchingPosts = SearchPosts(searchQueryParameters.Query);

                int matchingTotalItems = matchingPosts.Count;
                int matchingPageSize = searchQueryParameters.PageSize;
                int matchingTotalPages = (int)Math.Ceiling((double)matchingTotalItems / matchingPageSize);
                int matchingPageNumber = searchQueryParameters.PageNumber;

                var paginatedMatchingPosts = matchingPosts
                    .Skip((matchingPageNumber - 1) * matchingPageSize)
                    .Take(matchingPageSize)
                    .ToList();

                return new PaginatedList<Post>(paginatedMatchingPosts, matchingTotalPages, matchingPageNumber);
            }

            var filteredPosts = postRepository.GetAllPosts();


            // сортинг
            if (searchQueryParameters.SortBy == "likes_desc")
            {
                filteredPosts = filteredPosts.OrderByDescending(p => p.Likes?.Count ?? 0).ToList();
            }
            else if (searchQueryParameters.SortBy == "likes_asc")
            {
                filteredPosts = filteredPosts.OrderBy(p => p.Likes?.Count ?? 0).ToList();
            }
            else if (searchQueryParameters.SortBy == "date_desc")
            {
                filteredPosts = filteredPosts.OrderByDescending(p => p.DateCreated).ToList();
            }
            else if (searchQueryParameters.SortBy == "date_asc")
            {
                filteredPosts = filteredPosts.OrderBy(p => p.DateCreated).ToList();
            }
            else if (searchQueryParameters.SortBy == "title_desc")
            {
                filteredPosts = filteredPosts.OrderByDescending(p => p.Title).ToList();
            }
            else if (searchQueryParameters.SortBy == "title_asc")
            {
                filteredPosts = filteredPosts.OrderBy(p => p.Title).ToList();
            }
            else if (searchQueryParameters.SortBy == "createdBy_desc")
            {
                filteredPosts = filteredPosts.OrderByDescending(p => p.User.Username).ToList();
            }
            else if (searchQueryParameters.SortBy == "createdBy_asc")
            {
                filteredPosts = filteredPosts.OrderBy(p => p.User.Username).ToList();
            }


            // филтри
            if (!string.IsNullOrEmpty(searchQueryParameters.Title))
            {
                filteredPosts = filteredPosts.Where(p => p.Title.Contains(searchQueryParameters.Title, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(searchQueryParameters.User))
            {
                filteredPosts = filteredPosts.Where(p => p.User.Username.Contains(searchQueryParameters.User, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(searchQueryParameters.Content))
            {
                filteredPosts = filteredPosts.Where(p => p.Content.Contains(searchQueryParameters.Content, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(searchQueryParameters.TagValue))
            {
                filteredPosts = filteredPosts.Where(p => p.Tags.Any(t => t.Value == searchQueryParameters.TagValue)).ToList();
            }


            int totalItems = filteredPosts.Count;
            int pageSize = searchQueryParameters.PageSize;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            int pageNumber = searchQueryParameters.PageNumber;

            
            var paginatedPosts = filteredPosts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedList<Post>(paginatedPosts, totalPages, pageNumber);
        }

        public List<Post> SearchPosts(string query)
        {
            var allPosts = postRepository.GetAllPosts();
            var matchingPosts = allPosts
                .Where(p => p.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || p.Content.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return matchingPosts;
        }

    }
}
