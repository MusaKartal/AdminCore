using AdminCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options) 
        { 
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> admins { get; set; }

        
    }
}
