using AutoMapper;
using DataAccessLayer.Models;
using DTOs.CategoryDtos;
using DTOs.OrderDtos;
using DTOs.OrderItemDtos;
using DTOs.ProductDtos;
using DTOs.PromocodeDtos;

namespace DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(c => c.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Order, OrderDto>()
                .ForMember(c => c.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<AddOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>();

            CreateMap<Order, OrderItemDto>();
            CreateMap<AddOrderItemDto, Order>();
            CreateMap<UpdateOrderItemDto, Order>();

            CreateMap<Product, ProductDto>()
                .ForMember(c => c.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<AddProductDo, Product>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<Promocode, PromocodeDto>();
            CreateMap<AddPromocodeDto, Promocode>();
            CreateMap<UpdatePromocodeDto, Promocode>();
        }
    }
}
