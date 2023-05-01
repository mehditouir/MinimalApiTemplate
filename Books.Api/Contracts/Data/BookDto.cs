namespace Books.Api.Contracts.Data
{
    public class BookDto
    {
        public string Id { get; init; } = default!;

        public string Publisher { get; init; } = default!;

        public string Title { get; init; } = default!;

        public int Pages { get; init; } = default!;
        public string Editor { get; init; } = default!;

        public DateTime ReleaseDate { get; init; }
    }
}
