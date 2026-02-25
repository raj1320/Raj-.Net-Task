using AutoMapper;
using ASP.NETCORE_WEB_API_Project1.Application.DTOs;
using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
namespace ASP.NETCORE_WEB_API_Project1.Application.Mappings
{
    public class ProductProfile : Profile  
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateDto,Product>();

            CreateMap<Product, ProductCreateDto>();
            
            CreateMap<Product, ProductShowDto>().ForMember(dest=>dest.Category,opt=>opt.MapFrom(src=>src.Category.ToString()));

            CreateMap<ProductShowDto,Product>();

            CreateMap<Product, DeleteProductDTO>();

           


        }
    }
}
