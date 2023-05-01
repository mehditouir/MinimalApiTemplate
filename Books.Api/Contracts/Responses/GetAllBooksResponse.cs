namespace Books.Api.Contracts.Responses;

public class GetAllBooksResponse
{
    public IEnumerable<BookResponse> Books { get; init; } = Enumerable.Empty<BookResponse>();
}
