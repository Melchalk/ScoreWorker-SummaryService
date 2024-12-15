using SummaryService.Models.Db;

namespace SummaryService.Data.Interfaces;

public interface ISummaryRepository
{
    Task<DbSummary> GetAsync(Guid id);
    Task CreateAsync(DbSummary dbSummary);
    Task UpdateAsync(DbSummary dbSummary);
    Task DeleteAsync(Guid id);
}
