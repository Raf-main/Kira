namespace Kira.Infrastructure.Shared.Repositories.MongoDb;

public class MongoOptions
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}