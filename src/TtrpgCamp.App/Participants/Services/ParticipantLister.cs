using Microsoft.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Participants.Dtos;

namespace TtrpgCamp.App.Participants.Services;

public class ParticipantLister(TtrpgCampDbContext dbContext) : IParticipantsLister
{
    public async Task<IList<ParticipantDetailDto>> GetAllParticipantsAsync(CancellationToken cancellationToken)
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
            .ToListAsync(cancellationToken);
    }
}