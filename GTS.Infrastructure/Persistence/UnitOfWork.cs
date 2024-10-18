using GTS.Domain.Bases;
using GTS.Domain.GTS;
using GTS.Infrastructure.Persistence.GTS;

namespace GTS.Infrastructure.Persistence;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public IGeoTimeSeriesRepository GeoTimeSeries { get; } = new GeoTimeSeriesRepository(context);

    public async Task<int> CompleteAsync()
        => await _context.SaveChangesAsync();

    public void Dispose()
        => _context.Dispose();
}
