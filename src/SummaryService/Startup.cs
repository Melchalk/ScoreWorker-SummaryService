using AutoMapper;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using SummaryService.Business.Summary;
using SummaryService.Business.Summary.Interfaces;
using SummaryService.Data;
using SummaryService.Data.Interfaces;
using SummaryService.Data.Provider;
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

        //ConfigureMassTransit(services);

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

    private void ConfigureMassTransit(IServiceCollection services)
    {
        ConfigurePublishers(services);

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost");
                cfg.ConfigureEndpoints(context);
            });

            ConfigureConsumers(busConfigurator);
        });
    }

    private void ConfigurePublishers(IServiceCollection services)
    {
        //services.AddScoped<IMessagePublisher<CreateLibraryRequest, CreateLibraryResponse>, CreateLibraryMessagePublisher>();
    }

    private void ConfigureConsumers(IServiceCollectionBusConfigurator x)
    {
        //x.AddConsumer<>();
    }

    private void ConfigureDI(IServiceCollection services)
    {
        services.AddScoped<IDataProvider, SummaryServiceDbContext>();

        services.AddScoped<ISummaryRepository, SummaryRepository>();

        services.AddScoped<ICreateSummaryCommand, CreateSummaryCommand>();
        services.AddScoped<IDeleteSummaryCommand, DeleteSummaryCommand>();
        services.AddScoped<IGetFullReportCommand, GetFullReportCommand>();
        services.AddScoped<IGetSummaryCommand, GetSummaryCommand>();
        services.AddScoped<IUpdateSummaryCommand, UpdateSummaryCommand>();
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