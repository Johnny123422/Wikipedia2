using Microsoft.EntityFrameworkCore;
using Wikipedia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Wikipedia.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Domeniu> Domenii { get; set; }
        public DbSet<Articol> Articole { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var moderator = new IdentityRole
            {
                Id = "2",
                Name = "moderator",
                NormalizedName = "MODERATOR"
            };


            var userNeinregistrat = new IdentityRole
            {
                Id = "3",
                Name = "userNeinregistrat",
                NormalizedName = "USERNEINREGISTRAT"
            };


            var userInregistrat = new IdentityRole
            {
                Id = "4",
                Name = "userInregistrat",
                NormalizedName = "USERINREGISTRAT"
            };

            builder.Entity<IdentityRole>().HasData(admin, moderator, userNeinregistrat, userInregistrat);
        }

    }
}


