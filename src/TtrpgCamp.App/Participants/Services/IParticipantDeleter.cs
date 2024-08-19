using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Participants.Services;

public interface IParticipantDeleter
{
    Task DeleteAsync(Participant entity, CancellationToken token = default);
    
    Task DeleteAsync(Guid id, CancellationToken token = default);
}