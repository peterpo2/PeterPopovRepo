using AutoMapper;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;

namespace Gaming_Forum.Helpers
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<UserUpdateDto, User>();
            CreateMap<Post, PostUserResponseDto>().ForMember(c => c.Likes, opt => opt.MapFrom(src => src.Likes.Where(l => l.IsDeleted == false).Count()));
            CreateMap<Like, LikeResponseDto>().ForMember(c => c.Post, opt => opt.MapFrom(src => src.Post.Title));
            CreateMap<UserCreatedDto, User>();
            CreateMap<PostDto, Post>();
            CreateMap<Post, PostResponseDto>();
            CreateMap<CommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>().ForMember(c => c.CreatedBy, opt => opt.MapFrom(src =>src.User.Username))
                                                    .ForMember(c => c.Likes, opt => opt.MapFrom(src => src.Likes.Where(l => l.IsDeleted == false).Count()))
                                                    .ForMember(c => c.PostTitle, opt => opt.MapFrom(src => src.Post.Title));

            CreateMap<User, UserResponseDto>();
                        
        }
    }

}
