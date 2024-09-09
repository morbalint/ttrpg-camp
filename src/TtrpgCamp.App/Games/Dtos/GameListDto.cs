namespace TtrpgCamp.App.Games.Dtos;

public class GameListDto
{
    public required Guid Id { get; init; }

    public required string Title { get; init; }
    
    public required DateTime StartAt { get; init; }
    
    public required int ActPlayers { get; init; }
    
    public required int MaxPlayers { get; init; }
    
    public required string GameMasterName { get; init; }
    
    public required string GameMasterEmail { get; init; }
    
    public string? GameMasterPhone { get; init; }
}