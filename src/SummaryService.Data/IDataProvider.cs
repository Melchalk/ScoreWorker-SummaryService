using Microsoft.EntityFrameworkCore;
using SummaryService.Models.Db;

namespace SummaryService.Data;

/// <summary>
/// Data provider with DbSets of the app.
/// </summary>
public interface IDataProvider : IBaseDataProvider
{
    DbSet<DbSummary> Summary { get; set; }
    DbSet<DbScoreCriteria> ScoreCriteria { get; set; }
    DbSet<DbStatistics> Statistics { get; set; }
}