using AutoMapper;
using Gaming_Forum.Models;
using Gaming_Forum.Models.Dto;
using Gaming_Forum.Models.ViewModels;

namespace Gaming_Forum.Helpers
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            //Post mapping
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, PostDto>();
            CreateMap<UpdatePostViewModel, Post>();
            CreateMap<Post, PostUserResponseDto>().ForMember(c => c.Likes, opt => opt.MapFrom(src => src.Likes.Where(l => l.IsDeleted == false).Count()));
            CreateMap<PostDto, Post>();
            CreateMap<Post, PostResponseDto>();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<PostViewModel, Post>();

            //Like mapping
            CreateMap<Like, LikeResponseDto>().ForMember(c => c.Post, opt => opt.MapFrom(src => src.Post.Title));

            //User mapping
            CreateMap<User, UserResponseDto>();
            CreateMap<RegisterViewModel, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreatedDto, User>();
            CreateMap<User, RegisterViewModel>();

            //Comment mpping
            CreateMap<Comment, CommentRequestDto>();
            CreateMap<CommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>().ForMember(c => c.CreatedBy, opt => opt.MapFrom(src =>src.User.Username))
                                                    .ForMember(c => c.Likes, opt => opt.MapFrom(src => src.Likes.Where(l => l.IsDeleted == false).Count()))
                                                    .ForMember(c => c.PostTitle, opt => opt.MapFrom(src => src.Post.Title));
            //Tag mpping
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();


            //Reply mapping
            CreateMap<ReplyRequestDto, Reply>();
            CreateMap<Reply, ReplyResponseDto>();
            

        }
    }

}
