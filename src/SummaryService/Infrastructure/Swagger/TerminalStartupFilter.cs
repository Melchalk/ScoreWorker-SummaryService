using SummaryService.Infrastructure.Middlewares;

namespace SummaryService.Infrastructure.Swagger;

public class TerminalStartupFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            app.UseMiddleware<RequestLoggingMiddleware>();
            next(app);
        };
    }
}