using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SummaryService.Models.Dto.Enum;
using System.ComponentModel.DataAnnotations;

namespace SummaryService.Models.Db;

public class DbScoreCriteria
{
    public const string TableName = "ScoreCriterias";

    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ScoreCriteriaType Type { get; set; }
    public int Score { get; set; }
    public required string Description { get; set; }
}

public class DbScoreCriteriaConfiguration : IEntityTypeConfiguration<DbScoreCriteria>
{
    public void Configure(EntityTypeBuilder<DbScoreCriteria> builder)
    {
        builder.ToTable(DbScoreCriteria.TableName);
    }
}