using AutoMapper;
using SummaryService.Business.Summary.Interfaces;
using SummaryService.Data.Interfaces;
using SummaryService.Models.Dto.Exceptions;
using SummaryService.Models.Dto.Responses;
using System.Net;

namespace SummaryService.Business.Summary;

public class GetSummaryCommand(
    IMapper mapper,
    ISummaryRepository repository) : IGetSummaryCommand
{
    public async Task<ResponseInfo<GetSummaryResponse>> ExecuteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var dbReviewer = await repository.GetAsync(id, cancellationToken)
            ?? throw new BadRequestException($"Summaty with id = '{id}' was not found.");

        var reviewer = mapper.Map<GetSummaryResponse>(dbReviewer);

        return new ResponseInfo<GetSummaryResponse>
        {
            Body = reviewer,
            Status = (int)HttpStatusCode.OK,
        };
    }
}
