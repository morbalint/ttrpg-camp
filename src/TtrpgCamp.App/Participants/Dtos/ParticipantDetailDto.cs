namespace TtrpgCamp.App.Participants.Dtos;

public class ParticipantDetailDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string? Phone { get; set; }
}