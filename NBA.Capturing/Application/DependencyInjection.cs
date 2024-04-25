using NBA.Capturing.Application.Services;

namespace NBA.Capturing.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IPacketService, PacketService>();
        return services;
    }
}
