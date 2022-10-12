using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;

namespace Temp.Service.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }

        public string Desc { get; set; }

        public int CategoryId { get; set; }

        public int NSXId { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Status { get; set; }

        public int ProductType { get; set; }

        public Category Category { get; set; }

        public NSX NSX { get; set; }
    }
}
