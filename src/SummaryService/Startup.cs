using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SummaryService.Data;
using SummaryService.DataProvider.PostgreSql.Ef;
using SummaryService.Infrastructure.Mapper;
using SummaryService.Infrastructure.Middlewares;

namespace SummaryService;

internal class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        services.AddDbContext<SummaryServiceDbContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("SQLConnectionString"));
        });

        services.AddSingleton(new MapperConfiguration(mc =>
        {
            mc.AddProfile<MappingProfile>();
        }).CreateMapper());

        services.AddControllers();

        ConfigureDI(services);

        services.AddEndpointsApiExplorer();

        services.AddHttpContextAccessor();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
        services.AddAuthorization();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("CorsPolicy");

        app.UseHttpsRedirection();

        app.UseMiddleware<GlobalExceptionMiddleware>();

        UpdateDatabase(app);

        app.UseRouting();

        app.UseMiddleware<TokenMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private void ConfigureDI(IServiceCollection services)
    {
        services.AddScoped<IDataProvider, SummaryServiceDbContext>();
    }

    private void UpdateDatabase(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        using var context = serviceScope.ServiceProvider
            .GetService<SummaryServiceDbContext>();

        context!.Database.Migrate();
    }
}