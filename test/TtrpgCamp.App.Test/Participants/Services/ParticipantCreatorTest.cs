using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Dtos;
using TtrpgCamp.App.Participants.Services;

namespace TtrpgCamp.App.Test.Participants.Services;

[TestSubject(typeof(ParticipantCreator))]
public class ParticipantCreatorTest
{
    private readonly Mock<TtrpgCampDbContext> _dbContextMock = new();
    private readonly IParticipantCreator _sut;

    public ParticipantCreatorTest()
    {
        _sut = new ParticipantCreator(_dbContextMock.Object);
    }
    
    
    [Fact]
    public async Task CreateAsync_ShouldCreateNewParticipant()
    {
        // Arrange
        _dbContextMock.Setup(x => x.Participants).ReturnsDbSet([]);

        ParticipantCreateDto input = new()
        {
            Name = "John Doe",
            Email = "john.doe@gmail.com",
            Phone = "123456789",
        };
        
        // Act
        await _sut.CreateAsync(input);
        
        // Assert
        _dbContextMock.Verify(x => x.Participants.Add(It.Is<Participant>(x =>
            x.Name == "John Doe" && x.Email == "john.doe@gmail.com" && x.Phone == "123456789"
            )), Times.Once);
        _dbContextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
    }
}