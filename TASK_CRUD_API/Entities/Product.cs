using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TASK_CRUD_API.Entities
{
    public class Product : BaseEntity
    {

        [Required(ErrorMessage = "Please enter a Name")]
        [MinLength(5, ErrorMessage = "Description must be greater than 5 characters!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Price")]

        [Range(typeof(decimal), "1", "79228162514264337593543950335",ErrorMessage = "Price Must be greater than 0")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        //[JsonIgnore]
        public Category Category { get; set; }

    }
}
