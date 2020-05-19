using Microsoft.EntityFrameworkCore;

namespace EF_Test
{   
    class CurrencyContext :DbContext
    {
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Currencies;Trusted_Connection=True;");
        }
    }
}
