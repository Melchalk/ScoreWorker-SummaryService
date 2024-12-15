using SummaryService.Data.Interfaces;
using SummaryService.Data.Provider;
using SummaryService.Models.Db;

namespace SummaryService.Data;

public class SummaryRepository(IDataProvider provider) : ISummaryRepository
{
    public Task CreateAsync(DbSummary dbSummary)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DbSummary> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(DbSummary dbSummary)
    {
        throw new NotImplementedException();
    }
}
