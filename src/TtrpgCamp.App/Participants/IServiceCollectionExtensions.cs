using TtrpgCamp.App.Participants.Services;

namespace TtrpgCamp.App.Participants;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddParticipantServices(this IServiceCollection services)
    {
        services.AddTransient<IParticipantsLister, ParticipantLister>();
        services.AddTransient<IParticipantCreator, ParticipantCreator>();
        services.AddTransient<IParticipantLoader, ParticipantLoader>();
        services.AddTransient<IParticipantDeleter, ParticipantDeleter>();
        return services;
    }
}