
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Contracts.Persistence;
using SneddsyWorkspace.Apps.KratoApi.KratoApiPersistence.Repositories;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiPersistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, string connStr)
    {
        return services
            .AddDbContexts(connStr)
            .AddRepositories();
    }
    
    private static IServiceCollection AddDbContexts(this IServiceCollection services, string connStr)
    {
        return services.AddDbContext<KratoDbContext>(opts => opts.UseSqlite(connStr));
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IExerciseRepository, ExerciseRepository>();
    }
}