using SummaryService.Business.Summary.Interfaces;
using SummaryService.Data.Interfaces;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary;

public class GetFullReportCommand(ISummaryRepository repository) : IGetFullReportCommand
{
    public Task<ResponseInfo<GetReportResponse>> ExecuteAsync(
        Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
