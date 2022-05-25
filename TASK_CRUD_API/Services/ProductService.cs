using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_CRUD_API.Entities;
using TASK_CRUD_API.UnitOfWorks;

namespace TASK_CRUD_API.Services
{
    public class ProductService : Service<Product>,IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork,
            IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _repository = productRepository;
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _repository.GetProductsWithCategory();
        }
    }
}
