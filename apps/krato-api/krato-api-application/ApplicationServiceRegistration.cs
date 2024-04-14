using Microsoft.Extensions.DependencyInjection;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiApplication;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplictationServices(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        return services
            .AddAutoMapper(assemblies)
            .AddMediatR(config => config.RegisterServicesFromAssemblies(assemblies));
    }
}