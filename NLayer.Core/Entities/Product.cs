using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_CRUD_API.Entities
{
    public class Product : BaseEntity
    {
    
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
}
