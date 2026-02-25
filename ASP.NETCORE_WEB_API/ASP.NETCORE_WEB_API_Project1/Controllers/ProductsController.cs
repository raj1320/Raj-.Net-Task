using ASP.NETCORE_WEB_API_Project1.Application.DTOs;
using ASP.NETCORE_WEB_API_Project1.Application.Interface;
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
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto productDto)
        {
            var result = _productService.AddProductService(productDto);
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


        [HttpPut]
        [Route("{id}")]
        public IActionResult PutProduct(ProductCreateDto productCreateDto,int id)
        {
            var result = _productService.PutProductService( productCreateDto,id);
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
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
