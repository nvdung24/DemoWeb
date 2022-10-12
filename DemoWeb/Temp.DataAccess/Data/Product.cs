using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Temp.DataAccess.Data
{
    public class Product
    {
        [require]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(Max)")]
        public string Name { get; set; }
        public int? Amount { get; set; }
        public int? Price { get; set; }
        [Column(TypeName = "ntext")]
        public string Desc { get; set; }
        [require]
        public int CategoryId { get; set; }
        [require]
        public int NSXId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "nvarchar(Max)")]
        public string Avatar { get; set; }
        [require]
        public int ProductType { get; set; }
        public Category Category { get; set; }
        public NSX NSX { get; set; }
    }
}
