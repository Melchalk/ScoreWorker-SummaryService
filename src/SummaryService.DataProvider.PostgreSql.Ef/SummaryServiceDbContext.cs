using Microsoft.EntityFrameworkCore;
using SummaryService.Data.Provider;
using SummaryService.Models.Db;
using System.Reflection;

namespace SummaryService.DataProvider.PostgreSql.Ef;

public class SummaryServiceDbContext(DbContextOptions<SummaryServiceDbContext> options)
    : DbContext(options), IDataProvider
{
    public DbSet<DbSummary> Summaries { get; set; }
    public DbSet<DbScoreCriteria> ScoreCriteria { get; set; }
    public DbSet<DbStatistics> Statistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load(typeof(DbSummary).Assembly.FullName!));
    }

    public object MakeEntityDetached(object obj)
    {
        Entry(obj).State = EntityState.Detached;
        return Entry(obj).State;
    }

    async Task IBaseDataProvider.SaveAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }

    void IBaseDataProvider.Save()
    {
        SaveChanges();
    }

    public void EnsureDeleted()
    {
        Database.EnsureDeleted();
    }

    public bool IsInMemory()
    {
        return Database.IsInMemory();
    }
}