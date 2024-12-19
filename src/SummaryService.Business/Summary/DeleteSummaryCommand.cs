using SummaryService.Business.Summary.Interfaces;
using SummaryService.Data.Interfaces;
using SummaryService.Models.Dto.Exceptions;
using SummaryService.Models.Dto.Responses;
using System.Net;

namespace SummaryService.Business.Summary;

public class DeleteSummaryCommand(ISummaryRepository repository) : IDeleteSummaryCommand
{
    public async Task<ResponseInfo<bool>> ExecuteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var result = await repository.DeleteAsync(id, cancellationToken);

        if (!result)
            throw new BadRequestException($"Summary with id = '{id}' was not found.");

        return new ResponseInfo<bool>
        {
            Body = result,
            Status = (int)HttpStatusCode.OK,
        };
    }
}
