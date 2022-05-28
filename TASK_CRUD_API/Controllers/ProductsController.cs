using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_CRUD_API.Entities;
using TASK_CRUD_API.Services;

namespace TASK_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
     
        private readonly IProductService _service;

       

        public ProductsController(IProductService productService)
        {
            _service = productService;
        }
        [HttpGet]
         public async Task<List<Product>> GetAllProducts()
        {
            var products = await _service.GetAllAsync();

            return products;
        }

        [HttpGet("[action]")]
        public async Task<List<Product>> GetAllProductsWithCategory()
        {
            var productsWithCategory = await _service.GetProductsWithCategory();

            return productsWithCategory;
        }
        [HttpGet("{id}")]
        public async Task<Product> GetSingleProductById(int id)
        {
            var singleProduct = await _service.GetByIdAsync(id);
            return singleProduct;
        }

        [HttpPost]
        public async Task<Product> AddProduct([FromBody] Product product)
        {
            var addedProduct = new Product()
            {
                CreateDate = DateTime.UtcNow,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price

            };
            Console.WriteLine(addedProduct.Category);
            await _service.AddAsync(addedProduct);
            return addedProduct;
        }
        [HttpPut("{id}")]
        public async Task<Product> UpdateProduct(int id,[FromBody] Product product)
        {

            var updatedProduct = await _service.GetByIdAsync(id);
            updatedProduct.Category = product.Category;
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.Description = product.Description;
            updatedProduct.Name = product.Name;
            updatedProduct.Price = product.Price;
            await _service.UpdateAsync(updatedProduct);

            return product;

        }

        [HttpDelete("{id}")]
        public async Task<Product> DeleteProduct(int id)
        {
            var removedProduct = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(removedProduct);
            return removedProduct;
        }
    }
}
