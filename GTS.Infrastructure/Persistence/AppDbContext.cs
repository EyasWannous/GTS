using GTS.Domain.GTS;
using Microsoft.EntityFrameworkCore;

namespace GTS.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<GeoTimeSeries> GeoTimeSeries { get; set; }
    public DbSet<DataPoint> DataPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
