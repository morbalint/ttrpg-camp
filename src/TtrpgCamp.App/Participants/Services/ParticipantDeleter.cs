using Microsoft.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;

namespace TtrpgCamp.App.Participants.Services;

public class ParticipantDeleter(TtrpgCampDbContext dbContext) : IParticipantDeleter
{
    public Task DeleteAsync(Participant entity, CancellationToken token = default)
    {
        dbContext.Participants.Remove(entity);
        return dbContext.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(Guid id, CancellationToken token = default)
    {
        var entity = await dbContext.Participants.SingleAsync(p => p.Id == id, token);
        dbContext.Participants.Remove(entity);
        await dbContext.SaveChangesAsync(token);
    }
}