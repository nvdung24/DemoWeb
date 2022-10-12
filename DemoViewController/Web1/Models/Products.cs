using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webdemo1.Models
{
    /// <summary>
    /// san pham
    /// </summary>
    public class Products
    {
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        public int Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Categories Category { get; set; }
    }
}
