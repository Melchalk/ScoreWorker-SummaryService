using SummaryService.Models.Db;

namespace SummaryService.Data.Interfaces;

public interface ISummaryRepository
{
    Task<DbSummary?> GetAsync(Guid id, CancellationToken cancellationToken));
    Task<Guid> CreateAsync(DbSummary dbSummary, CancellationToken cancellationToken));
    Task<bool> UpdateAsync(DbSummary dbSummary, CancellationToken cancellationToken));
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken));
}
