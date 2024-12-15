using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SummaryService.Models.Dto.Enum;
using System.ComponentModel.DataAnnotations;

namespace SummaryService.Models.Db;

public class DbSummary
{
    public const string TableName = "Summaries";

    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public SummaryType Type { get; set; }
    public required string Summary { get; set; }

    public List<DbStatistics>? Statistics { get; set; }
}

public class DbSummaryConfiguration : IEntityTypeConfiguration<DbSummary>
{
    public void Configure(EntityTypeBuilder<DbSummary> builder)
    {
        builder.ToTable(DbSummary.TableName);

        builder.HasMany(s => s.Statistics)
            .WithOne(st => st.Summary)
            .HasForeignKey(st => st.SummaryId);
    }
}