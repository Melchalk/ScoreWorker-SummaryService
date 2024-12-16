using SummaryService.Business.Summary.Interfaces;
using SummaryService.Data.Interfaces;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary;

public class GetSummaryCommand(ISummaryRepository repository) : IGetSummaryCommand
{
    public Task<ResponseInfo<GetSummaryResponse>> ExecuteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
