using Inventory.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ComputerEntity> Computers { get; set; }
    }
}
