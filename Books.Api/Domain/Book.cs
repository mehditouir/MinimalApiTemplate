
using Books.Api.Domain.Common;

namespace Books.Api.Domain
{
    public class Book
    {
        public BookId Id { get; init; } = BookId.From(Guid.NewGuid());

        public BookPublisher Publisher { get; init; } = default!;
        public BookTitle Title { get; init; } = default!;

        public BookPageCount Pages { get; init; } = default!;

        public BookEditor Editor { get; init; } = default!;

        public BookReleaseDate ReleaseDate { get; init; } = default!;
    }
}
