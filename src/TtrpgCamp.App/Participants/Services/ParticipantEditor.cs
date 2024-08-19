using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Participants.Services;

public class ParticipantEditor(TtrpgCampDbContext dbContext) : IParticipantEditor
{
    public Task Edit(Participant participant, CancellationToken token = default)
    {
        var alreadyTracked = dbContext.ChangeTracker.Entries<Participant>().Any(x => x.Entity == participant);
        if (!alreadyTracked)
        {
            var entry = dbContext.Participants.Attach(participant);
            foreach (var member in entry.Members)
            {
                member.IsModified = true;
            }
        }
        
        return dbContext.SaveChangesAsync(token);
    }
}