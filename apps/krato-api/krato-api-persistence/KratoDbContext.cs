using SneddsyWorkspace.Apps.KratoApi.KratoApiDomain.Entities;

using Microsoft.EntityFrameworkCore;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiPersistence;

public class KratoDbContext : DbContext
{
    public KratoDbContext(DbContextOptions<KratoDbContext> options) : base(options) {}

    public DbSet<Exercise> Exercises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KratoDbContext).Assembly);
        
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise()
            {
                Id = Guid.NewGuid(),
                Name = "Push Ups"
            });

        base.OnModelCreating(modelBuilder);
    }
}