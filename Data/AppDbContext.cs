using Microsoft.EntityFrameworkCore;
using Wikipedia.Models;

namespace Wikipedia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Autor> Autori { get; set; }
        public DbSet<Domeniu> Domenii { get; set; }
        public DbSet<Articol> Articole { get; set; }
        public DbSet<Comentariu> Comentarii { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domeniu>().HasData(
                new Domeniu { Id = 1, Nume = "Istorie" },
                new Domeniu { Id = 2, Nume = "Tehnologie" }
            );

            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nume = "Mihai Popescu" },
                new Autor { Id = 2, Nume = "Ioana Georgescu" }
            );

            modelBuilder.Entity<Articol>().HasData(
                new Articol { Id = 1, Titlu = "Revolutia Franceza", Continut = "Un articol despre revolutia franceza...", DomeniuId = 1, AutorId = 1 },
                new Articol { Id = 2, Titlu = "AI in 2025", Continut = "Despre inteligenta artificiala in viitor...", DomeniuId = 2, AutorId = 2 }
            );

            modelBuilder.Entity<Comentariu>().HasData(
                new Comentariu { Id = 1, ArticolId = 1, Continut = "Foarte interesant!" },
                new Comentariu { Id = 2, ArticolId = 2, Continut = "Excelent articol!" },
                new Comentariu { Id = 3, ArticolId = 2, Continut = "Mai vreau articole despre AI." }
            );

        }

    }
}


