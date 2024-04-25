using NBA.Management.Infrastructure.Options;
using NBA.Management.Infrastructure;
using NBA.Capturing.Infrastructure.Factories;

namespace NBA.Capturing.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoConnectionOptions>(configuration.GetSection("MongoOptions:Client"));
        services.AddSingleton<IMongoClientFactory, MongoClientFactory>();
        services.Configure<ManagementDbOptions>(configuration.GetSection("MongoOptions:Databases:0"));
        services.Configure<PacketsCollectionOptions>(configuration.GetSection("MongoOptions:Databases:0:Collections:0"));
        services.AddSingleton<IManagementDbFactory, ManagementDbFactory>();
        services.AddSingleton<IPacketsCollectionFactory, PacketsCollectionFactory>();
        return services;
    }
}
