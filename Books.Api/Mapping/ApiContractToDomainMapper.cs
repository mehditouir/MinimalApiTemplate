using Books.Api.Contracts.Requests;
using Books.Api.Domain;
using Books.Api.Domain.Common;

namespace Books.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Book ToBook(this CreateBookRequest request)
    {
        return new Book
        {
            Id = BookId.From(Guid.NewGuid()),
            Title = BookTitle.From(request.Title),
            Editor = BookEditor.From(request.Editor),
            Pages = BookPageCount.From(request.Pages),
            Publisher = BookPublisher.From(request.Publisher),
            ReleaseDate = BookReleaseDate.From(DateOnly.FromDateTime(request.ReleaseDate))
        };
    }

    public static Book ToBook(this UpdateBookRequest request)
    {
        return new Book
        {
            Id = BookId.From(request.Id),
            Title = BookTitle.From(request.Title),
            Editor = BookEditor.From(request.Editor),
            Pages = BookPageCount.From(request.Pages),
            Publisher = BookPublisher.From(request.Publisher),
            ReleaseDate = BookReleaseDate.From(DateOnly.FromDateTime(request.ReleaseDate))
        };
    }
}
