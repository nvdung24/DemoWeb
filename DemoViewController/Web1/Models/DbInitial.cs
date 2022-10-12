using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webdemo1.Models
{
    public static class DbInitial
    {
        public static void Initial(DataContext context, IConfiguration configuration)
        {
            if (!((RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>()).Exists())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
