using Microsoft.EntityFrameworkCore;
using SummaryService.Data.Interfaces;
using SummaryService.Data.Provider;
using SummaryService.Models.Db;

namespace SummaryService.Data;

public class SummaryRepository(IDataProvider provider) : ISummaryRepository
{
    public async Task<Guid> CreateAsync(
        DbSummary dbSummary, CancellationToken cancellationToken)
    {
        await provider.Summaries.AddAsync(dbSummary, cancellationToken);

        await provider.SaveAsync(cancellationToken);

        return dbSummary.Id;
    }

    public async Task<bool> DeleteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var dbSummary = await provider.Summaries
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (dbSummary is null)
            return false;

        provider.Summaries.Remove(dbSummary);

        await provider.SaveAsync(cancellationToken);

        return true;
    }

    public async Task<DbSummary?> GetAsync(
        Guid id, CancellationToken cancellationToken)
    {
        return await provider.Summaries
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<bool> UpdateAsync(
        DbSummary dbSummary, CancellationToken cancellationToken)
    {
        await provider.SaveAsync(cancellationToken);

        return true;
    }
}
