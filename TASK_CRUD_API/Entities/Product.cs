using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TASK_CRUD_API.Entities
{
    public class Product : BaseEntity
    {
    
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        //[JsonIgnore]
        public Category Category { get; set; }

    }
}
