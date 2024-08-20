using JetBrains.Annotations;
using Moq;
using Moq.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Services;

namespace TtrpgCamp.App.Test.Participants.Services;

[TestSubject(typeof(ParticipantDeleter))]
public class ParticipantDeleterTest
{
    private readonly Mock<TtrpgCampDbContext> _dbContext = new();
    private readonly IParticipantDeleter _sut;

    public ParticipantDeleterTest()
    {
        _sut = new ParticipantDeleter(_dbContext.Object);
    }
    
    [Fact]
    public async Task DeleteAsync_ShouldDeleteParticipant()
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
        await _sut.DeleteAsync(participant);

        // Assert
        _dbContext.Verify(x => x.Participants.Remove(participant), Times.Once);
        _dbContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }
    
    [Fact]
    public async Task DeleteAsync_ById_ShouldDeleteParticipant()
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
        await _sut.DeleteAsync(participant.Id);

        // Assert
        _dbContext.Verify(x => x.Participants.Remove(participant), Times.Once);
        _dbContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }
}