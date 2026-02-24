using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Repositories;

namespace ASP.NETCORE_WEB_API_Project1.Application.Services
{
    public class ProductService 
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product? AddProductService(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public Product? GetProductService(int id) 
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetCategoryService(Category category)
        {
            return _productRepository.GetCategory(category);
        }

        public IEnumerable<Product> GetProductsService()
        {
            return _productRepository.GetProducts();
        }

        public bool DeleteProductService(int id)
        {
           
            return _productRepository.DeleteProduct(id);
        }

    }
}
