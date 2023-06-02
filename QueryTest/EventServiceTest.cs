using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RelatedToOneEntity.DbContexts;
using RelatedToOneEntity.Services;

namespace QueryTest;

public class EventServiceTest: IClassFixture<QueryDbTestFixture>
{
    private readonly QueryDbTestFixture mySqlContainer;

    public EventServiceTest(QueryDbTestFixture fixture)
    {
        this.mySqlContainer = fixture;
    }
    
    [Fact]
    public async Task TestGetEventWithFullDependents_IfMultipleDependentsCanBeFiltered()
    {
        // arrange
        //
        var service = new EventService(
            new TestDbContext(mySqlContainer.Options));
        
        // act
        //
        var result = await service.GetEventWithFullDependents(1);
        
        // assert
        //
        result.Name.Should().Be("event1");
        result.Many1s.Count.Should().Be(1);
        result.Many1s.ToList()[0].OneId.Should().Be(2);
        result.Many2s.Count.Should().Be(1);
        result.Many2s.ToList()[0].OneId.Should().Be(2);
    }
}