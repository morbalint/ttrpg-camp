using TtrpgCamp.App.Games.Services;

namespace TtrpgCamp.App.Games;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGameServices(this IServiceCollection services)
    {
        services.AddTransient<IGamesLister, GamesLister>();
        return services;
    }
}