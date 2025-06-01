using Microsoft.EntityFrameworkCore;
using Wikipedia.Models;

namespace Wikipedia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Domeniu> Domenii { get; set; }
        public DbSet<Articol> Articole { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domeniu>().HasData(
                new Domeniu { Id = 1, Nume = "Istorie" },
                new Domeniu { Id = 2, Nume = "Tehnologie" }
            );

           

            

        }

    }
}


