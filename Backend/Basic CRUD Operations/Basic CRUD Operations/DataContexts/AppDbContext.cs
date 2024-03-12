using Basic_CRUD_Operations.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Basic_CRUD_Operations.DataContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
