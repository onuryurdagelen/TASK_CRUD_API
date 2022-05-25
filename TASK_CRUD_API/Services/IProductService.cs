using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_CRUD_API.Entities;

namespace TASK_CRUD_API.Services
{
    public interface IProductService: IService<Product>
    {
        Task<List<Product>> GetProductsWithCategory();
    }
}
