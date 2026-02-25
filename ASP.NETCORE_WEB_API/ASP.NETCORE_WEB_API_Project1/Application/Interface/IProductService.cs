using ASP.NETCORE_WEB_API_Project1.Application.DTOs;
using ASP.NETCORE_WEB_API_Project1.Domain.Enums;


namespace ASP.NETCORE_WEB_API_Project1.Application.Interface
{
    public interface IProductService
    {
       
        public ProductCreateDto? AddProductService(ProductCreateDto product);


        public ProductShowDto? GetProductService(int id);


        public List<ProductShowDto> GetCategoryService(Category category);


        public IEnumerable<ProductShowDto> GetProductsService();

        public ProductCreateDto? PutProductService(ProductCreateDto product,int id);

        public DeleteProductDTO? DeleteProductService(int id);


        
    }
}
