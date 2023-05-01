using Books.Api.Contracts.Data;

namespace Books.Api.Repositories;

public interface IBookRepository
{
    Task<bool> CreateAsync(BookDto customer);

    Task<BookDto?> GetAsync(Guid id);

    Task<IEnumerable<BookDto>> GetAllAsync();

    Task<bool> UpdateAsync(BookDto customer);

    Task<bool> DeleteAsync(Guid id);
}
