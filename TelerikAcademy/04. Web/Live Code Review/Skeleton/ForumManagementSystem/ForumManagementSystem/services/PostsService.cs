using ForumManagementSystem.Exceptions;
using ForumManagementSystem.Models;
using ForumManagementSystem.Repositories;
using System;

namespace ForumManagementSystem.services
{
    public class PostsService : IPostsService
    {
        private readonly IPostsRepository postsRepository;

        public PostsService(IPostsRepository postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        //public void AddLike(int postId, User user)
        //{
        //    throw new NotImplementedException();
        //}

        public void Create(Post post, User author)
        {
            postsRepository.Create(post, author);
        }

        public void Delete(int id, User user)
        {
            postsRepository.Delete(id);
        }

        public List<Post> Filter(PostFitlerParameters fitlerParameters)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
            return postsRepository.GetAll();
        }

        public List<Post> GetAllPostsByUser(User user)
        {
            return postsRepository.GetAllPostsByUser(user);
        }

        public Post GetById(int id)
        {
            return postsRepository.GetByPostId(id);
        }

        public List<Post> GetMostCommented()
        {
            List<Post> all = postsRepository.GetAll();
            all = all.OrderByDescending(post => post.Comments.Count)
                .Take(10)
                .ToList();
            return all;
        }

        //public List<Post> GetMostLiked()
        //{
        //    return postsRepository.GetAll()
        //        .OrderByDescending(post => post.Likes.Count)
        //        .Take(10)
        //        .ToList();
        //}

        public List<Post> GetNewest()
        {
            List<Post> all = postsRepository.GetAll();
            all = all.OrderBy(post => post.Date)
                    .Take(10)
                    .ToList();
            return all;
        }

        public void Update(Post post, User user, int id)
        {
            Post postToUpdate = postsRepository.GetByPostId(id);
            if (postToUpdate.Author != user)
            {
                throw new UnauthorizedAccessException("You are not the author");
            }

            postsRepository.Update(post);
        }
    }
}
