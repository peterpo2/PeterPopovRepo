using ForumManagementSystem.Models;
using ForumManagementSystem.Repositories;

namespace ForumManagementSystem.Mappers
{
    public class CommentMapper
    {
        private readonly IUsersRepository usersRepository;
        private readonly IPostsRepository postsRepository;
        private readonly ICommentsRepository commentsRepository;

        public CommentMapper(IUsersRepository usersRepository, IPostsRepository postsRepository, ICommentsRepository commentsRepository)
        {
            this.usersRepository = usersRepository;
            this.postsRepository = postsRepository;
            this.commentsRepository = commentsRepository;
        }

        public Comment dtoToObject(CommentDTO commentDto, User user)
        {
            Post post = postsRepository.GetByPostId(commentDto.postId);
            return new Comment()
            {
                Author = user,
                Content = commentDto.Content,
                Post = post,
                Date = DateTime.Now
            };
        }

        public Comment dtoToObject(CommentDTO commentDto, User user, Post post)
        {
            return new Comment()
            {
                Author = user,
                Content = commentDto.Content,
                Post = post,
                Date = DateTime.Now
            };
        }

        public Comment dtoToObject(CommentDTO commentDto, int id)
        {
            Comment comment = commentsRepository.GetById(id);
            comment.Content = commentDto.Content;
            return comment;
        }

        public CommentDTO toDto(Comment comment, Post post)
        {
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.Content = comment.Content;
            commentDTO.postId = comment.Id;
            return commentDTO;
        }
    }
}
