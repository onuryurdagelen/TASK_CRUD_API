using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_CRUD_API.Entities;

namespace TASK_CRUD_API.Repositories
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {

        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public Task<List<Category>> GetCategoriesWithProducts()
        {
            return _context.Categories.Include(c => c.Products).ToListAsync();
        }
    }

}
