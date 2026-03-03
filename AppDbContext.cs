using Microsoft.EntityFrameworkCore;
using Pinkleaf_Collection.Models;

namespace Pinkleaf_Collection.Dtabasecode
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
