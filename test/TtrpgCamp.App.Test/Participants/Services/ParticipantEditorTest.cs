using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Services;

namespace TtrpgCamp.App.Test.Participants.Services;

[TestSubject(typeof(ParticipantEditor))]
public class ParticipantEditorTest
{
    private readonly Mock<TtrpgCampDbContext> _dbContext = new();
    private readonly IParticipantEditor _sut;

    public ParticipantEditorTest()
    {
        _sut = new ParticipantEditor(_dbContext.Object);
    }
    
    [Fact]
    public async Task EditAsync_ShouldEditParticipant()
    {
        // Arrange
        Participant participant = new()
        {
            Id = Guid.NewGuid(),
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            Phone = "123456789",
        };
        _dbContext.Setup(x => x.Participants).ReturnsDbSet([participant]);
        
        // Act
        await _sut.EditAsync(participant);
        
        // Assert
        _dbContext.Verify(x => x.Participants.Update(participant), Times.Once);
        _dbContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }
}
