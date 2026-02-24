using ASP.NETCORE_WEB_API_Project1.Application.Services;
using ASP.NETCORE_WEB_API_Project1.Domain.Entities;
using ASP.NETCORE_WEB_API_Project1.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCORE_WEB_API_Project1.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService) 
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var result = _productService.AddProductService(product);
            if (result == null) 
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id) 
        {

            var result = _productService.GetProductService(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("category/{categoryName}")]
        public IActionResult GetProducts(Category categoryName) 
        {
            var result = _productService.GetCategoryService(categoryName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.GetProductsService();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProductService(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
