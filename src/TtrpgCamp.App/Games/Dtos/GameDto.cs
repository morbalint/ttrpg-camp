namespace TtrpgCamp.App.Games.Dtos;

public class GameDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";
    
    public int ActPlayers { get; set; }
    
    public int MaxPlayers { get; set; }
    
    public DateTime StartAt { get; set; }
    
    public DateTime EndAt { get; set; }
    
    public string GameMasterName { get; set; }
    
    public string? Description { get; set; }
    
    public string? ImagePath { get; set; }
    
    public string? Link { get; set; }
}