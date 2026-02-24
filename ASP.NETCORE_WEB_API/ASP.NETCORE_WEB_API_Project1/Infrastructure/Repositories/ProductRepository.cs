using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCORE_WEB_API_Project1.Infrastructure.Repositories
{
    public class ProductRepository
    {
        AppDbContext _Context;

        public ProductRepository (AppDbContext context)
        {
            _Context = context;
        }

        public Product? AddProduct(Product product) 
        {
             _Context.Products.Add(product);
             _Context.SaveChanges();
             return product;
           
        }

        public Product? GetProductById(int id)
        {
            var product = _Context.Products.SingleOrDefault(x=>x.Id == id);
            return product;
        }

        public List<Product> GetCategory(Category category) 
        {
            var products = _Context.Products.Where(x=>x.Category == category).ToList();
            return products;
        }

        public IEnumerable<Product> GetProducts() 
        {
            return _Context.Products.AsNoTracking().ToList();
        }

        public bool DeleteProduct(int id)
        {
            var products = _Context.Products.SingleOrDefault(x => x.Id == id);
            
            if (products != null)
            {
                _Context.Products.Remove(products);
                _Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
