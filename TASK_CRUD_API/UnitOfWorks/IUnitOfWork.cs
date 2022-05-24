using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_CRUD_API.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); //SaveChangesAsync()
        void Commit(); //SaveChanges()
    }
}
