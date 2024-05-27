using Microsoft.EntityFrameworkCore;
using WebApp4BySuraj.Models;

namespace WebApp4BySuraj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
