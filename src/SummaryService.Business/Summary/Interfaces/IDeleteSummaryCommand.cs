using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary.Interfaces;

public interface IDeleteSummaryCommand
{
    Task<ResponseInfo<bool>> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}
