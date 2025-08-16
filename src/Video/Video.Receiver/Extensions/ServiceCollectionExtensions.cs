using Microsoft.Extensions.DependencyInjection;
using Video.Receiver.Services;

namespace Video.Receiver.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddReceiverServices(this IServiceCollection services)
    {
        services.AddHostedService<VideoMetadataReceiver>();
        return services;
    }
}
