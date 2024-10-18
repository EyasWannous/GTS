using GTS.Domain.GTS;

namespace GTS.Domain.Bases;

public interface IUnitOfWork : IDisposable
{
    IGeoTimeSeriesRepository GeoTimeSeries { get; }

    Task<int> CompleteAsync();
}
