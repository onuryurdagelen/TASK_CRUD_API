using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_CRUD_API;
using TASK_CRUD_API.Entities;
using TASK_CRUD_API.Services;
using TASK_CRUD_WEB.Models;

namespace TASK_CRUD_WEB.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly AppDbContext _context;

        public CategoriesController(ICategoryService categoryService, AppDbContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();

            foreach (var item in categories)
            {
                Console.WriteLine(item.Name);
            }

            ViewBag.categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Save(Category category)
        {
            
            var addedCategory = new Category()
            {
                CreateDate = DateTime.UtcNow,
                Description = category.Description,
                Name = category.Name

            };
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(addedCategory);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            var categories = await _categoryService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name", category.Id);

            return View(category);
        }

        [HttpPost]

        public async Task<IActionResult> Update(Category category)
        {
            var createdDate = _context.Categories.Where(c => c.Id == category.Id).Select(x => x.CreateDate).FirstOrDefault();

            Console.WriteLine(createdDate);
            var updatedCategory = new Category()
            {
                Id = category.Id,
                CreateDate = createdDate,
                Description = category.Description,
                Name = category.Name,

            };

            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(updatedCategory);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name", category.Id);

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var selectedCategory = await _categoryService.GetByIdAsync(id);

            await _categoryService.RemoveAsync(selectedCategory);
            return RedirectToAction(nameof(Index));
        }


    }
}
