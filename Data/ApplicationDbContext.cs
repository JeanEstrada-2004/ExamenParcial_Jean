using Microsoft.EntityFrameworkCore;
using ExamenParcial_Jean.Models;

namespace ExamenParcial_Jean.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasIndex(a => new { a.PlayerId, a.TeamId })
                .IsUnique();

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Player)
                .WithMany(p => p.Assignments)
                .HasForeignKey(a => a.PlayerId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Team)
                .WithMany(t => t.Assignments)
                .HasForeignKey(a => a.TeamId);
        }
    }
}
