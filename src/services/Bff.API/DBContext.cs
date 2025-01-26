using Bff.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bff.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
                entity.Property(u => u.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsRequired(false);
            });
        }
    }

    
}
