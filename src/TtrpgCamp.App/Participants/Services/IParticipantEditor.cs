using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Participants.Services;

public interface IParticipantEditor
{
    Task EditAsync(Participant participant, CancellationToken token = default);
}