using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webdemo1.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Products> Products { get; set; }
         
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
