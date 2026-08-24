using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Twitter_Klon1.Models;

namespace Twitter_Klon1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext(options)
    {
        public DbSet<Twitter_Klon1.Models.Dislike> Dislike { get; set; } = default!;
        public DbSet<Twitter_Klon1.Models.Like> Like { get; set; } = default!;
        public DbSet<Twitter_Klon1.Models.Beitrag> Beitrag { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Like>()
                .HasIndex(l => new { l.UserId, l.BeitragId })
                .IsUnique();
        }
    }
}
