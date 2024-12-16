using SummaryService.Business.Summary.Interfaces;
using SummaryService.Data.Interfaces;
using SummaryService.Models.Dto.Requests;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary;

public class CreateSummaryCommand(ISummaryRepository repository) : ICreateSummaryCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(
        CreateSummaryRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
