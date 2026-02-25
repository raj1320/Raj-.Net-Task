using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using ASP.NETCORE_WEB_API_Project1.Infrastructure.Data;
using ASP.NETCORE_WEB_API_Project1.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCORE_WEB_API_Project1.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
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

        public Product? PutProduct(Product product,int id)
        {
            var Oldproduct = GetProductById(id);

            if (Oldproduct == null) { return null; }

            Oldproduct.Name= product.Name;
            Oldproduct.Price= product.Price;
            Oldproduct.VandorName= product.VandorName;
            Oldproduct.Category = product.Category;
            Oldproduct.Description= product.Description;
            Oldproduct.Stock= product.Stock;
            Oldproduct.IsAvailable= true;

            _Context.SaveChanges();

            return Oldproduct;

        }

        public Product? DeleteProduct(int id)
        {
            var products = _Context.Products.SingleOrDefault(x => x.Id == id);
            
            if (products != null)
            {
                _Context.Products.Remove(products);
                _Context.SaveChanges();
                return products;
            }
            return null;
        }
    }
}
