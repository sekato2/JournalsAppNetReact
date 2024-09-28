using Journals.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journals.Infraestructure.Persistence;

internal class JournalDbContext(DbContextOptions<JournalDbContext> options) : DbContext(options)
{
    internal DbSet<Journal> Journals { get; set; }
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasMany(y => y.Journals)
            .WithOne()
            .HasForeignKey(y => y.OwnerId);

        modelBuilder.Entity<User>()
            .HasMany(y => y.Subscriptions)
            .WithMany(y => y.Subscribers);
    }
}
