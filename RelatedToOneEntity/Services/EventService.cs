using Microsoft.EntityFrameworkCore;
using RelatedToOneEntity.DbContexts;
using RelatedToOneEntity.Entities;

namespace RelatedToOneEntity.Services;

public class EventService
{
    private TestDbContext dbContext;
    
    public EventService(TestDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Event> GetEventWithFullDependents(long eventId)
    {
        DateTime effectiveDate = DateTime.Now.AddDays(-7);
        
        var result = await dbContext.Events.Where(e => e.Id == eventId)
            .Include(e => e.Many1s.Where(m => m.Created > effectiveDate))
            .ThenInclude(m => m.Message)
            .Include(e => e.Many2s.Where(m => m.Created > effectiveDate))
            .ThenInclude(m => m.Message)
            .SingleOrDefaultAsync();

        if (result == null)
        {
            throw new InvalidOperationException($"can not find event with id {eventId}");
        }

        return result;
    }
}