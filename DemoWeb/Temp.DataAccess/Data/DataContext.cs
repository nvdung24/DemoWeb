using Microsoft.EntityFrameworkCore;

namespace Temp.DataAccess.Data
{    
    /// <summary>
    /// DbContext
    /// </summary>
    public class DataContext : DbContext
    {                      
        /// <summary>
        /// role
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// user
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<NSX> NSXs { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }
}