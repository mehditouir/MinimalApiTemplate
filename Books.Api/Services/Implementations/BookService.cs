using Books.Api.Domain;
using Books.Api.Mapping;
using Books.Api.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Books.Api.Services.Implementations;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<bool> CreateAsync(Book book)
    {
        var existingUser = await _bookRepository.GetAsync(book.Id.Value);
        if (existingUser is not null)
        {
            var message = $"A book with id {book.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Book), message)
            });
        }

        var bookDto = book.ToBookDto();
        return await _bookRepository.CreateAsync(bookDto);
    }

    public async Task<Book?> GetAsync(Guid id)
    {
        var bookDto = await _bookRepository.GetAsync(id);
        return bookDto?.ToBook();
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var bookDtos = await _bookRepository.GetAllAsync();
        return bookDtos.Select(x => x.ToBook());
    }

    public async Task<bool> UpdateAsync(Book book)
    {
        var bookDto = book.ToBookDto();
        return await _bookRepository.UpdateAsync(bookDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _bookRepository.DeleteAsync(id);
    }
}
