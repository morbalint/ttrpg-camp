using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Participants.Services;

public class ParticipantEditor(TtrpgCampDbContext dbContext) : IParticipantEditor
{
    public Task EditAsync(Participant participant, CancellationToken token = default)
    {
        dbContext.Participants.Update(participant);
        return dbContext.SaveChangesAsync(token);
    }
}
