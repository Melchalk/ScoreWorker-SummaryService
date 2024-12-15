using SummaryService.Business.Summary.Interfaces;
using SummaryService.Models.Dto.Requests;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary;

public class UpdateSummaryCommand : IUpdateSummaryCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(
        UpdateSummaryRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
