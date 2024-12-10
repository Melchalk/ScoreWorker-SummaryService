using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SummaryService.Controllers;

[SwaggerTag("Управление отзывами")]
[Authorize]
[ApiController]
[Route("api/summary")]
[Produces("application/json")]
public class SummaryController : ControllerBase
{

}
