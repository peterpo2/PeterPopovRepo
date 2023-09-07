using ForumManagementSystem.Models;
using ForumManagementSystem.services;

namespace ForumManagementSystem.Mappers
{
    public class PostMapper
    {
        private readonly IPostsService postsService;

        public PostMapper(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public Post DtoToObject(PostDTO postDTO, User user)
        {
            return new Post()
            {
                Title = postDTO.Title,
                Content = postDTO.Content,
                Date = DateTime.Now,
                Author = user
            };
        }

        public Post DtoToObject(PostDTO postDTO, int id)
        {
            Post post = postsService.GetById(id);
            post.Title = postDTO.Title;
            post.Content = postDTO.Content;
            return post;
        }

        public PostDTO toDto(Post post)
        {
            PostDTO postDTO = new PostDTO();
            postDTO.Title = post.Title;
            postDTO.Content = post.Content;
            return postDTO;
        }
    }
}
