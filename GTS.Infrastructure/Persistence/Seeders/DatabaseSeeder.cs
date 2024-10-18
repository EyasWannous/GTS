using System.Data;

namespace GTS.Infrastructure.Persistence.Seeders;

public class DatabaseSeeder(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task SeedAsync()
    {
        await SeedGeo();
    }

    private async Task SeedGeo()
    {
        if (_context.GeoTimeSeries.Any())
            return;
        
        var data = GeoTimeSeriesSeeder.GetData();

        await _context.GeoTimeSeries.AddRangeAsync(data);

        await _context.SaveChangesAsync();
    }
}
