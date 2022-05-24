using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_CRUD_API.Services
{
    public interface IService<T> where T: class
    {
        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);
    }
}
