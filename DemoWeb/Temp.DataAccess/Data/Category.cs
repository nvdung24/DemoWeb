using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Temp.DataAccess.Data
{
    public class Category
    {
        [require]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
