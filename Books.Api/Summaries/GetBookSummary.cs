using Books.Api.Contracts.Responses;
using Books.Api.Endpoints;
using FastEndpoints;

namespace Books.Api.Summaries;

public class GetBookSummary : Summary<GetBookEndpoint>
{
    public GetBookSummary()
    {
        Summary = "Returns a single book by id";
        Description = "Returns a single book by id";
        Response<GetAllBooksResponse>(200, "Successfully found and returned the book");
        Response(404, "The book does not exist in the system");
    }
}
