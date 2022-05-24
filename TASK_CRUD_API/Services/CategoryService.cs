using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_CRUD_API.Entities;
using TASK_CRUD_API.UnitOfWorks;

namespace TASK_CRUD_API.Services
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _repository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoriesWithProductsAsync()
        {
            return await _repository.GetCategoriesWithProducts();
        }
    }
}
