using Microsoft.EntityFrameworkCore;

namespace zadanie5.Models
{
    public class TestDbContext : DbContext
    {
        public DbSet<Klienci> Klienci { get; set; }
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)

        {
        }
        
    }
}
