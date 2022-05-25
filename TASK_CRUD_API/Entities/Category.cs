using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TASK_CRUD_API.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Please enter a Name")]
        [MinLength(5, ErrorMessage = "Name must be greater than 5 characters!")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
