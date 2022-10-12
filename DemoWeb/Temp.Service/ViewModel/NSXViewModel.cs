using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;

namespace Temp.Service.ViewModel
{
    public class NSXViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
