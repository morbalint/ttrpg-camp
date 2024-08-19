using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Participants.Services;

public interface IParticipantEditor
{
    Task Edit(Participant participant, CancellationToken token = default);
}