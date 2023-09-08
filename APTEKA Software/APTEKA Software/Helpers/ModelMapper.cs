using APTEKA_Software.Models.Dto;
using APTEKA_Software.Models;
using AutoMapper;
using APTEKA_Software.Models.ViewModels;

namespace APTEKA_Software.Helpers
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            // User mapping
            CreateMap<User, UserResponseDto>();
            CreateMap<RegisterViewModel, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<UserCreatedDto, User>();
            CreateMap<User, RegisterViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel,User >();

            // Delivery mapping
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryDto, Delivery>();

            // Sale mapping
            CreateMap<Sale, SaleDto>();
            CreateMap<SaleDto, Sale>()
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());

            CreateMap<SaleViewModel, Sale>()
                     .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => DateTime.Now))
                     .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                     .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
                     .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                     .ForMember(dest => dest.UserId, opt => opt.Ignore());

            // SaleResult mapping
            CreateMap<SaleResult, SaleResultDto>();
            CreateMap<SaleResultDto, SaleResult>();

            // Item mapping
            CreateMap<Item, ItemDto>()
                     .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.AvailableQuantity))
                     .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.SalePrice))
                     .ReverseMap();
            CreateMap<ItemDto, Item>();
            CreateMap<Item, ItemViewModel>();
            CreateMap<ItemViewModel, Item>();
            CreateMap<ItemViewModel, ItemDto>();
            CreateMap<ItemDto, Item>()
           .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.AvailableQuantity))
           .ForMember(dest => dest.SalePrice, opt => opt.MapFrom(src => src.SalePrice));

        }
    }
}
