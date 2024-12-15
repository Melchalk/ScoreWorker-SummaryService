using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary.Interfaces;

public interface IGetFullReportCommand
{
    Task<ResponseInfo<GetReportResponse>> ExecuteAsync(
        Guid userId, CancellationToken cancellationToken);
}
