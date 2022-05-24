using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T: class
    {

        IQueryable<T> GetAll();

        Task AddAsync(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}
