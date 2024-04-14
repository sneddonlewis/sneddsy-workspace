using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication;
using SneddsyWorkspace.Apps.KratoApi.KratoApiPersistence;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApi;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        string dbConnStr = builder.Configuration["ConnectionStrings:KratoDbConnectionString"]!;
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddApplictationServices();
        builder.Services.AddPersistenceServices(dbConnStr);
        builder.Services.AddControllers();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app
            // .UseCors("open")
            .UseHttpsRedirection();
        app
            .MapControllers();
        return app;
    }
}