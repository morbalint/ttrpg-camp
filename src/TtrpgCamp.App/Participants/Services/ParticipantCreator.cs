using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Dtos;

namespace TtrpgCamp.App.Participants.Services;

public class ParticipantCreator(TtrpgCampDbContext dbContext) : IParticipantCreator
{
    public Task CreateAsync(ParticipantCreateDto dto, CancellationToken token = default)
    {
        var entity = new Participant
        {
            Name = dto.Name,
            Email = dto.Email,
            Phone = dto.Phone,
        };
        dbContext.Participants.Add(entity);
        return dbContext.SaveChangesAsync(token);
    }
}