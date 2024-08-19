using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Dtos;

namespace TtrpgCamp.App.Participants.Services;

public interface IParticipantLoader
{
    Task<Participant?> GetParticipantAsync(Guid id, CancellationToken token = default);
    
    Task<ParticipantDetailDto?> GetReadonlyParticipantAsync(Guid id, CancellationToken token = default);
}