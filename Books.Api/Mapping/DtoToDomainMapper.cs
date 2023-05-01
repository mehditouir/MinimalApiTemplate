using Books.Api.Contracts.Data;
using Books.Api.Domain;
using Books.Api.Domain.Common;

namespace Books.Api.Mapping;

public static class DtoToDomainMapper
{
    public static Book ToBook(this BookDto bookDto)
    {
        return new Book
        {
            Id = BookId.From(Guid.Parse(bookDto.Id)),
            Title = BookTitle.From(bookDto.Title),
            Editor = BookEditor.From(bookDto.Editor),
            Publisher = BookPublisher.From(bookDto.Publisher),
            Pages = BookPageCount.From(bookDto.Pages),
            ReleaseDate = BookReleaseDate.From(DateOnly.FromDateTime(bookDto.ReleaseDate))
        };
    }
}
