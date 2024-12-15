using SummaryService.Business.Summary.Interfaces;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary;

public class GetFullReportCommand : IGetFullReportCommand
{
    public Task<ResponseInfo<GetReportResponse>> ExecuteAsync(
        Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
