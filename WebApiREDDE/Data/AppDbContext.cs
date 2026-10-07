using Microsoft.EntityFrameworkCore;
using WebApiREDDE.Models;

namespace WebApiREDDE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
    }
}
