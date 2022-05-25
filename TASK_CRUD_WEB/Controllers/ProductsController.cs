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
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private readonly AppDbContext _context;

        public ProductsController(IProductService productService, ICategoryService categoryService,AppDbContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _context = context;
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
            int maxId = _context.Products.Max(x => x.Id);
            maxId++;
            var addedProduct = new Product() 
            {
                CreateDate = DateTime.UtcNow,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price

            };
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(addedProduct);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();

            ViewBag.categories = new SelectList((IEnumerable)categories, "Id", "Name");

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            var categories = await _categoryService.GetAllAsync();

            //var createdDate = _context.Products.Where(p => p.Id == id).Select(x => x.CreateDate).FirstOrDefault();

            //Console.WriteLine(createdDate);

            //product.CreateDate = createdDate;

            ViewBag.categories = new SelectList(categories, "Id", "Name",product.CategoryId);

            return View(product);
        }

        [HttpPost]

        public async Task<IActionResult> Update(Product product)
        {
            var createdDate = _context.Products.Where(p => p.Id == product.Id).Select(x => x.CreateDate).FirstOrDefault();

            Console.WriteLine(createdDate);
            var updatedProduct = new Product()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                CreateDate = createdDate,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price

            };

            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(updatedProduct);
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();

            ViewBag.categories = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var selectedProduct = await  _productService.GetByIdAsync(id);

            if (ModelState.IsValid)
            {
                await _productService.RemoveAsync(selectedProduct);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

       
    }
}
