using AutoMapper;
using SummaryService.Business.Summary.Interfaces;
using SummaryService.Data.Interfaces;
using SummaryService.Models.Db;
using SummaryService.Models.Dto.Requests;
using SummaryService.Models.Dto.Responses;
using System.Net;

namespace SummaryService.Business.Summary;

public class CreateSummaryCommand(
    IMapper mapper,
    ISummaryRepository repository) : ICreateSummaryCommand
{
    public async Task<ResponseInfo<Guid>> ExecuteAsync(
        CreateSummaryRequest request,
        CancellationToken cancellationToken)
    {
        var summary = mapper.Map<DbSummary>(request);

        var result = await repository.CreateAsync(summary, cancellationToken);

        return new ResponseInfo<Guid>
        {
            Body = result,
            Status = (int)HttpStatusCode.Created
        };
    }
}
