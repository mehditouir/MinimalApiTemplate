using Books.Api.Contracts.Data;
using Books.Api.Domain;

namespace Books.Api.Mapping;

public static class DomainToDtoMapper
{
    public static BookDto ToBookDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id.Value.ToString(),
            Title = book.Title.Value,
            Publisher = book.Publisher.Value,
            Pages = book.Pages.Value,
            Editor = book.Editor.Value,
            ReleaseDate = book.ReleaseDate.Value.ToDateTime(TimeOnly.MinValue)
        };
    }
}
