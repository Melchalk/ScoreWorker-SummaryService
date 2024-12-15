using SummaryService.Business.Summary.Interfaces;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Business.Summary;

public class DeleteSummaryCommand : IDeleteSummaryCommand
{
    public Task<ResponseInfo<bool>> ExecuteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
