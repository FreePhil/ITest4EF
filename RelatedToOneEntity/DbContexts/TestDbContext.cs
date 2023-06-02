using Microsoft.EntityFrameworkCore;
using RelatedToOneEntity.Entities;

namespace RelatedToOneEntity.DbContexts;

public class TestDbContext : DbContext
{
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Many1> Many1s { get; set; }
    public virtual DbSet<Many2> Many2s { get; set; }
    public virtual DbSet<One> Ones { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }    
}