using FluentAssertions;
using JetBrains.Annotations;
using Moq;
using Moq.EntityFrameworkCore;
using TtrpgCamp.App.Db;
using TtrpgCamp.App.Db.Entities;
using TtrpgCamp.App.Participants.Dtos;
using TtrpgCamp.App.Participants.Services;

namespace TtrpgCamp.App.Test.Participants.Services;

[TestSubject(typeof(ParticipantLister))]
public class ParticipantListerTest
{
    private readonly Mock<TtrpgCampDbContext> _dbContext = new();
    private readonly IParticipantsLister _sut;

    public ParticipantListerTest()
    {
        _sut = new ParticipantLister(_dbContext.Object);
    }
    
    [Fact]
    public async Task GetAllParticipantsAsync_ShouldReturnAllParticipants()
    {
        // Arrange
        List<Participant> participants =
        [
            new Participant
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "john@doe.com",
            },
            new Participant
            {
                Id = Guid.NewGuid(),
                Name = "Jane Doe",
                Email = "jane@doe.com",
                Phone = "08888888888",
            },
        ];

        List<ParticipantDetailDto> expected =
        [
            new ParticipantDetailDto
            {
                Id = participants[0].Id,
                Name = "John Doe",
                Email = "john@doe.com",
            },
            new ParticipantDetailDto
            {
                Id = participants[1].Id,
                Name = "Jane Doe",
                Email = "jane@doe.com",
                Phone = "08888888888",
            },
        ];
        
        _dbContext.Setup(x => x.Participants).ReturnsDbSet(participants);
        
        // Act
        var actual = await _sut.GetAllParticipantsAsync(default);

        // Assert
        actual.Should().SatisfyRespectively(
            first => first.Should().BeEquivalentTo(expected[0]),
            second => second.Should().BeEquivalentTo(expected[1])
            );
    }
}