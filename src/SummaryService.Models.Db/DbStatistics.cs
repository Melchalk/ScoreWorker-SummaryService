using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SummaryService.Models.Dto.Enum;
using System.ComponentModel.DataAnnotations;

namespace SummaryService.Models.Db;

public class DbStatistics
{
    public const string TableName = "Statistics";

    [Key]
    public Guid Id { get; set; }
    public Guid SummaryId { get; set; }
    public ReviewType Type { get; set; }
    public int Count { get; set; }

    public DbSummary? Summary { get; set; }
}

public class DbStatisticsConfiguration : IEntityTypeConfiguration<DbStatistics>
{
    public void Configure(EntityTypeBuilder<DbStatistics> builder)
    {
        builder.ToTable(DbStatistics.TableName);

        builder.HasOne(st => st.Summary)
            .WithMany(s => s.Statistics)
            .HasForeignKey(st => st.SummaryId);
    }
}