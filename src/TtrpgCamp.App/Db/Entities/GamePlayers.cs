using System.ComponentModel.DataAnnotations.Schema;

namespace TtrpgCamp.App.Db.Entities;

public class GamePlayers
{
    public Guid Id { get; set; }
    
    public Guid GameId { get; set; }
    
    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; } = null!;
    
    public Guid PlayerId { get; set; }
    
    [ForeignKey(nameof(PlayerId))]
    public Participant Player { get; set; } = null!;
}