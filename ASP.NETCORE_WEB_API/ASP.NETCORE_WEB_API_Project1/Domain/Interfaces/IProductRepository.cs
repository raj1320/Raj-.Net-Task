using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCORE_WEB_API_Project1.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Product? AddProduct(Product product);

        public Product? GetProductById(int id);


        public List<Product> GetCategory(Category category);


        public IEnumerable<Product> GetProducts();

        public Product? PutProduct(Product product,int id);

        public Product? DeleteProduct(int id);
        

    }
}
