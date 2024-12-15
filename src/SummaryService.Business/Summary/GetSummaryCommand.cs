using SummaryService.Business.Summary.Interfaces;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary;

public class GetSummaryCommand : IGetSummaryCommand
{
    public Task<ResponseInfo<GetSummaryResponse>> ExecuteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
