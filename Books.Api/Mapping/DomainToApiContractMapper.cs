using Books.Api.Contracts.Responses;
using Books.Api.Domain;

namespace Books.Api.Mapping;

public static class DomainToApiContractMapper
{
    public static BookResponse ToBookResponse(this Book book)
    {
        return new BookResponse
        {
            Id = book.Id.Value,
            Title = book.Title.Value,
            Publisher = book.Publisher.Value,
            Pages = book.Pages.Value,
            Editor = book.Editor.Value,
            ReleaseDate = book.ReleaseDate.Value.ToDateTime(TimeOnly.MinValue)
        };
    }

    public static GetAllBooksResponse ToBooksResponse(this IEnumerable<Book> books)
    {
        return new GetAllBooksResponse
        {
            Books = books.Select(x => new BookResponse
            {
                Id = x.Id.Value,
                Title = x.Title.Value,
                Publisher = x.Publisher.Value,
                Pages = x.Pages.Value,
                Editor = x.Editor.Value,
                ReleaseDate = x.ReleaseDate.Value.ToDateTime(TimeOnly.MinValue)
            })
        };
    }
}
