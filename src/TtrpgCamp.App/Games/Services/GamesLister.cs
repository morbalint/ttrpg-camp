using Microsoft.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Games.Dtos;

namespace TtrpgCamp.App.Games.Services;

public class GamesLister(TtrpgCampDbContext dbContext) : IGamesLister
{
    public async Task<List<GameListDto>> ListGamesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Games.AsNoTracking().Select(x => new GameListDto
        {
            Id = x.Id,
            Title = x.Title,
            StartAt = x.StartAt,
            MaxPlayers = x.MaxPlayers,
            ActPlayers = x.Players.Count,
            GameMasterName = x.GameMaster.Name,
            GameMasterEmail = x.GameMaster.Email,
            GameMasterPhone = x.GameMaster.Phone,
        }).ToListAsync(cancellationToken);
    }
}