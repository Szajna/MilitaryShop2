using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using MilitaryShop.Core.Models;

namespace MilitaryShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
