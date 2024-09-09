using Microsoft.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Dtos;

namespace TtrpgCamp.App.Participants.Services;

public class ParticipantLoader(TtrpgCampDbContext dbContext) : IParticipantLoader
{
    public async Task<Participant?> GetParticipantAsync(Guid id, CancellationToken token)
    {
        return await dbContext.Participants.FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public async Task<ParticipantDetailDto?> GetReadonlyParticipantAsync(Guid id, CancellationToken token)
    {
        return await dbContext.Participants
            .AsNoTracking()
            .Select(p => new ParticipantDetailDto
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
            })
            .FirstOrDefaultAsync(p => p.Id == id, token);
    }
}