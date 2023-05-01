using Dapper;

namespace Books.Api.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Books (
        Id CHAR(36) PRIMARY KEY, 
        Publisher TEXT NOT NULL,
        Title TEXT NOT NULL,
        Editor TEXT NOT NULL,
        Pages INTEGER NOT NULL,
        ReleaseDate TEXT NOT NULL)");
    }
}
