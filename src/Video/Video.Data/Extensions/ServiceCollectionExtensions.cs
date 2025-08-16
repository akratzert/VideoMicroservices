using Microsoft.Extensions.DependencyInjection;
using Video.Data.Interfaces;
using Video.Data.Services;

namespace Video.Data.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        //TODO: Register Dynamo Db

        services.AddSingleton<IVideoDataService, VideoDataService>();
        services.AddSingleton<IThemeDataService, ThemeDataService>();
        return services;
    }
}
