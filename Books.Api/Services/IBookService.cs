using Books.Api.Domain;

namespace Books.Api.Services;

public interface IBookService
{
    Task<bool> CreateAsync(Book book);

    Task<Book?> GetAsync(Guid id);

    Task<IEnumerable<Book>> GetAllAsync();

    Task<bool> UpdateAsync(Book book);

    Task<bool> DeleteAsync(Guid id);
}
