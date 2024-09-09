namespace TtrpgCamp.App.Games.Dtos;

public class GameCreateDto
{
    public string Title { get; set; } = "";

    public int MaxPlayers { get; set; }
    
    public DateTime StartAt { get; set; }
    
    public DateTime EndAt { get; set; }
    
    public Guid GameMasterParticipantId { get; set; }
    
    public string? Description { get; set; }
    
    public string? ImagePath { get; set; }
    
    public string? Link { get; set; }
}