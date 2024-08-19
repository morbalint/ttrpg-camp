namespace TtrpgCamp.App.Participants.Dtos;

public class ParticipantCreateDto
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string? Phone { get; set; }
}