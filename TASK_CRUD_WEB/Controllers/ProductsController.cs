using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_CRUD_API.Entities;
using TASK_CRUD_API.Services;
using TASK_CRUD_WEB.Models;

namespace TASK_CRUD_WEB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsWithCategory();
            return View(products);
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

        public async Task<IActionResult> Save(Product product)
        {
           
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();

            ViewBag.categories = new SelectList((IEnumerable)categories, "Id", "Name");

            return View();
        }

       
    }
}
