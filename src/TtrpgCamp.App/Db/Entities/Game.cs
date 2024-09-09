using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TtrpgCamp.App.Db.Entities;

public class Game
{
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; } = null!;
    
    public Guid GameMasterParticipantId { get; set; }
    
    [ForeignKey(nameof(GameMasterParticipantId))]
    public Participant GameMaster { get; set; } = null!;

    public int MaxPlayers { get; set; } = 5;
    
    public DateTime StartAt { get; set; }
    
    public DateTime EndAt { get; set; }
    
    public string? Description { get; set; }
    
    public string? ImagePath { get; set; }
    
    public string? Link { get; set; }
    
    public HashSet<GamePlayers> Players { get; set; } = [];
}