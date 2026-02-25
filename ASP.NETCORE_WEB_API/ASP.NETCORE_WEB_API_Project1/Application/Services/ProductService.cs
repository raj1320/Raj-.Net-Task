using ASP.NETCORE_WEB_API_Project1.Application.DTOs;
using ASP.NETCORE_WEB_API_Project1.Application.Interface;
using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using ASP.NETCORE_WEB_API_Project1.Domain.Interfaces;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Repositories;
using AutoMapper;

namespace ASP.NETCORE_WEB_API_Project1.Application.Services
{
    public class ProductService : IProductService
    {   
        private readonly IMapper _mapper;

        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductCreateDto? AddProductService(ProductCreateDto productDto)
        {
            var product= _mapper.Map<Product>(productDto);
            var resposnce =_productRepository.AddProduct(product);
            var finalResultDTO = _mapper.Map<ProductCreateDto>(resposnce);

            return finalResultDTO;
        }

        public ProductShowDto? GetProductService(int id) 
        {
            var product = _productRepository.GetProductById(id);
            var finalResultDTO = _mapper.Map<ProductShowDto>(product);
            
            return finalResultDTO;


        }

        public List<ProductShowDto> GetCategoryService(Category category)
        {
            var result = _productRepository.GetCategory(category);
            var ListOfproductShowDtos = _mapper.Map<List<ProductShowDto>>(result);
            return ListOfproductShowDtos;
        }

        public IEnumerable<ProductShowDto> GetProductsService()
        {
            var result = _productRepository.GetProducts();
            var ListOfproductShowDtos = _mapper.Map<List<ProductShowDto>>(result);
            return ListOfproductShowDtos;
        }

        public ProductCreateDto? PutProductService(ProductCreateDto product, int id)
        {
            var resultProduct = _mapper.Map<Product>(product);
            var resposnce = _productRepository.PutProduct(resultProduct,id);
            var finalResultDTO = _mapper.Map<ProductCreateDto>(resposnce);

            return finalResultDTO;
        }

        public DeleteProductDTO? DeleteProductService(int id)
        {

            var resut = _productRepository.DeleteProduct(id);

            return _mapper.Map<DeleteProductDTO>(resut);
        }

    }
}
