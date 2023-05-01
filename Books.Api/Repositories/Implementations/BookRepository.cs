using Books.Api.Contracts.Data;
using Books.Api.Database;
using Dapper;

namespace Books.Api.Repositories.Implementations;

public class BookRepository : IBookRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public BookRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(BookDto book)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Books (Id, Publisher, Title, Pages, Editor, ReleaseDate) 
            VALUES (@Id, @Publisher, @Title, @Pages, @Editor, @ReleaseDate)",
            book);
        return result > 0;
    }

    public async Task<BookDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<BookDto>(
            "SELECT * FROM Books WHERE Id = @Id LIMIT 1", new { Id = id.ToString() });
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<BookDto>("SELECT * FROM Books");
    }

    public async Task<bool> UpdateAsync(BookDto book)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Books SET Publisher = @Publisher, Title = @Title, Pages = @Pages, 
                 Editor = @Editor, ReleaseDate = @ReleaseDate WHERE Id = @Id",
            book);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(@"DELETE FROM Books WHERE Id = @Id",
            new { Id = id.ToString() });
        return result > 0;
    }
}
