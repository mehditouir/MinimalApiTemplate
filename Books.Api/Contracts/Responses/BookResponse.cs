namespace Books.Api.Contracts.Responses;

public class BookResponse
{
    public Guid Id { get; init; }

    public string Publisher { get; init; } = default!;
    public string Title { get; init; } = default!;

    public string Editor { get; init; } = default!;

    public int Pages { get; init; } = default!;

    public DateTime ReleaseDate { get; init; }
}
