using DotNet.Testcontainers.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RelatedToOneEntity.DbContexts;
using Testcontainers.MySql;

namespace QueryTest;

public class QueryDbTestFixture: IAsyncLifetime
{
    private MySqlContainer container;
    public DbContextOptions<TestDbContext> Options { get; private set; }

    public async Task InitializeAsync()
    {
        container = new MySqlBuilder()
            .WithBindMount(Path.GetFullPath("initsql"), "/docker-entrypoint-initdb.d")
            .WithImage("mysql:8.0.33")
            .WithDatabase("testdb")
            .WithUsername("phil")
            .WithPassword("henge")
            .WithExposedPort("3306")
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(3306))
            .Build();
        
        await container.StartAsync();

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        this.Options = new DbContextOptionsBuilder<TestDbContext>()
            .UseMySQL(container.GetConnectionString())
            .UseLoggerFactory(loggerFactory)
            .Options;
    }

    public async Task DisposeAsync()
    {
        if (container != null)
        {
            await container.StopAsync();
            await container.DisposeAsync();
        }
    }
}