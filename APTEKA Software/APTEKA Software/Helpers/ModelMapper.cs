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

            // Delivery mapping
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryDto, Delivery>();

            // Sale mapping
            CreateMap<Sale, SaleDto>();
            CreateMap<SaleDto, Sale>();

            // SaleResult mapping
            CreateMap<SaleResult, SaleResultDto>();
            CreateMap<SaleResultDto, SaleResult>();

            // Item mapping
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}
