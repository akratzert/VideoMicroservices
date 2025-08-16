using Microsoft.Extensions.DependencyInjection;
using Video.BusinessRules.Interfaces;
using Video.BusinessRules.Services;
using Video.Data.Extensions;

namespace Video.BusinessRules.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessRulesServices(this IServiceCollection services)
    {
        services.AddDataServices();

        services.AddSingleton<IVideoService, VideoService>();

        return services;
    }
}
