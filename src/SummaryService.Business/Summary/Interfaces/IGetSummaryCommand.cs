using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary.Interfaces;

public interface IGetSummaryCommand
{
    Task<ResponseInfo<GetSummaryResponse>> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}
