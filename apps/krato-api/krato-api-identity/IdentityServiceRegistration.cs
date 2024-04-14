using Microsoft.Extensions.DependencyInjection;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiIdentity;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, string dbConnectionString)
    {
        services
            .AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
    
        services
            .AddAuthorizationBuilder();

        services
            .AddDbContext<KratoIdentityDbContext>(opts => opts.UseSqlite(dbConnectionString));

        services
            .AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<KratoIdentityDbContext>()
            .AddApiEndpoints();
        
        return services;
    }
}