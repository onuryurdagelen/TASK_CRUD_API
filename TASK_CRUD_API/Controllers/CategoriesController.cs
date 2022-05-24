using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService categoryService)
        {
            _service = categoryService;
        }
        [HttpGet("[action]")]
        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _service.GetAllAsync();

            return categories;
        }

        [HttpGet("[action]")]
        public async Task<List<Category>> GetAllCategoriesWithProducts()
        {
            var categories = await _service.GetCategoriesWithProductsAsync();

            return categories;
        }
        [HttpPost]
        public async void AddCategory([FromBody] Category category)
        {
            await _service.AddAsync(category);
        }
        [HttpPut]
        public async void UpdateCategory([FromBody] Category category)
        {
            await _service.UpdateAsync(category);

        }

        [HttpDelete("{id}")]
        public async void DeleteCategory(int id)
        {
            var removedProduct = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(removedProduct);
        }
    }
}
