using TtrpgCamp.App.Participants.Dtos;

namespace TtrpgCamp.App.Participants.Services;

public interface IParticipantCreator
{
    Task CreateAsync(ParticipantCreateDto dto, CancellationToken cancellationToken = default);
}