using TtrpgCamp.App.Participants.Dtos;

namespace TtrpgCamp.App.Participants.Services;

public interface IParticipantsLister
{
    Task<IList<ParticipantDetailDto>> GetAllParticipantsAsync(CancellationToken cancellationToken);
}