using TtrpgCamp.App.Games.Dtos;

namespace TtrpgCamp.App.Games.Services;

public interface IGamesLister
{
    Task<List<GameListDto>> ListGamesAsync(CancellationToken cancellationToken = default);
}