using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummaryService.Business.Summary.Interfaces;
using SummaryService.Models.Dto.Requests;
using SummaryService.Models.Dto.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace SummaryService.Controllers;

[SwaggerTag("Управление отзывами")]
[Authorize]
[ApiController]
[Route("api/summary")]
[Produces("application/json")]
public class SummaryController : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseInfo<bool>> CreateAsync(
      [FromServices] ICreateSummaryCommand command,
      [FromBody] CreateSummaryRequest request,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(request, cancellationToken);
    }

    [HttpGet("get")]
    public async Task<ResponseInfo<GetSummaryResponse>> GetAsync(
      [FromServices] IGetSummaryCommand command,
      [FromQuery] Guid id,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(id, cancellationToken);
    }

    [HttpGet("get/report")]
    public async Task<ResponseInfo<GetReportResponse>> GetReportAsync(
      [FromServices] IGetFullReportCommand command,
      [FromQuery] Guid userId,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(userId, cancellationToken);
    }

    [HttpPut("update")]
    public async Task<ResponseInfo<bool>> UpdateAsync(
      [FromServices] IUpdateSummaryCommand command,
      [FromBody] UpdateSummaryRequest request,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(request, cancellationToken);
    }

    [HttpDelete("remove")]
    public async Task<ResponseInfo<bool>> RemoveAsync(
      [FromServices] IDeleteSummaryCommand command,
      [FromQuery] Guid id,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(id, cancellationToken);
    }
}