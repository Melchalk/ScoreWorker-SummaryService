using SummaryService.Models.Dto.Requests;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary.Interfaces;

public interface ICreateSummaryCommand
{
    Task<ResponseInfo<Guid>> ExecuteAsync(CreateSummaryRequest request, CancellationToken cancellationToken);
}
