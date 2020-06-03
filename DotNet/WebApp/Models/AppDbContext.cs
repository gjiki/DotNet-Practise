using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet <Course> Courses { get; set; }
        public DbSet <Currency> Currencies { get; set; }
        public DbSet <Operation> Operations { get; set; }
    }
}
