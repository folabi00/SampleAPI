using Microsoft.EntityFrameworkCore;
using SampleAPI.Models;

namespace SampleAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
           
        }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .Property(e => e.LastModified);
        }

        public bool StockExists(int id)
        {
            return Stocks.Any(s => s.Id.Equals(id));
        }
        public Stock? IsValid(int id)
        {
            return Stocks.FirstOrDefault(s => s.Id.Equals(id));

        }
        public bool StockNameExists(string name)
        {
            return Stocks.Any(s => s.Name.Equals(name));
        }
    }
}
