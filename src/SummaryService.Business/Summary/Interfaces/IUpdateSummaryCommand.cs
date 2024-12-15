using SummaryService.Models.Dto.Requests;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary.Interfaces;

public interface IUpdateSummaryCommand
{
    Task<ResponseInfo<bool>> ExecuteAsync(UpdateSummaryRequest request, CancellationToken cancellationToken);
}
