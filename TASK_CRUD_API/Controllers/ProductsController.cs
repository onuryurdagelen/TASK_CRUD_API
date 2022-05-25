﻿using Microsoft.AspNetCore.Http;
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
        private readonly AppDbContext _context;

       

        public ProductsController(IProductService productService, AppDbContext context)
        {
            _service = productService;
            _context = context;
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
        [HttpPost]
        public async void AddProduct([FromBody] Product product)
        {
            await _service.AddAsync(product);
        }
        [HttpPut]
        public async void UpdateProduct([FromBody] Product product)
        {
            await _service.UpdateAsync(product);

        }

        [HttpDelete("{id}")]
        public async void DeleteProduct(int id)
        {
            var removedProduct = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(removedProduct);
        }
    }
}
