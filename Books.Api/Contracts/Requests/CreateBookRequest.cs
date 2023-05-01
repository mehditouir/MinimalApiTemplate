namespace Books.Api.Contracts.Requests;

public class CreateBookRequest
{
    public string Publisher { get; init; } = default!;
    public string Title { get; init; } = default!;

    public string Editor { get; init; } = default!;

    public int Pages { get; init; } = default!;

    public DateTime ReleaseDate { get; init; }
}
