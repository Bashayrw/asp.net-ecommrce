using AutoMapper;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<UserCreateDto, User>();

            CreateMap<ProductCreateDto, Product>();
            CreateMap<Product, ProductReadDto>();
            CreateMap<Product, ProductWithStockReadDto>();
            CreateMap<ProductUpdateDto, Product>()
                        .ForAllMembers(opts => opts.Condition((src, dest, srcProperty) => srcProperty != null)); ;

            CreateMap<StockCreateDto, Stock>();
            CreateMap<Stock, StockReadDto>();

            CreateMap<CategoryReadDto, Category>();
            CreateMap<CategoryCreateDto, Category>();

            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryUpdateDto, Category>();


            CreateMap<OrderCheckout, OrderCheckoutUpdateDto>();
            CreateMap<OrderCheckout, OrderCheckoutUpdateDto>();



        }
    }
}