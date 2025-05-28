using Microsoft.EntityFrameworkCore;
using Wikipedia.Models;

namespace Wikipedia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Articol> Articole { get; set; }
        public DbSet<Domeniu> Domenii { get; set; }
    }
}

