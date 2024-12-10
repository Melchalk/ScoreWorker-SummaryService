using Pro.Pricer.Infrastructure.Middlewares;

namespace Pro.Pricer.Infrastructure.StartupFilters;

public class TerminalStartupFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return app =>
        {
            app.Map("/version",
                builder => builder.UseMiddleware<VersionMiddleware>());
            app.UseMiddleware<RequestLoggingMiddleware>();
            next(app);
        };
    }
}