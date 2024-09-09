using JetBrains.Annotations;
using Moq;
using Moq.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Services;

namespace TtrpgCamp.App.Test.Participants.Services;

[TestSubject(typeof(ParticipantLoader))]
public class ParticipantLoaderTest
{
    private readonly Mock<TtrpgCampDbContext> _dbContext = new();
    private readonly IParticipantLoader _sut;

    public ParticipantLoaderTest()
    {
        _sut = new ParticipantLoader(_dbContext.Object);
    }
    
    [Fact]
    public async Task GetParticipantAsync_ValidId_ReturnsParticipant()
    {
        // Arrange
        var participant = new Participant
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            Phone = "123456789",
        };
        var anotherParticipant = new Participant
        {
            Id = Guid.NewGuid(),
            Name = "Jane Doe",
            Email = "jane.doe@gmail.com",
            Phone = "901234567",
        };
        _dbContext.Setup(x => x.Participants).ReturnsDbSet([anotherParticipant, participant]);
        
        // Act
        var actual = await _sut.GetParticipantAsync(participant.Id);
        
        // Assert
        Assert.Equal(participant, actual);
    }
}