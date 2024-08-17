using System.ComponentModel.DataAnnotations;

namespace TtrpgCamp.App.Db.Entities;

public class Participant
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
    
    public string? Phone { get; set; }
}