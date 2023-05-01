using Books.Api.Contracts.Responses;
using Books.Api.Endpoints;
using FastEndpoints;

namespace Books.Api.Summaries;

public class GetAllBooksSummary : Summary<GetAllBooksEndpoint>
{
    public GetAllBooksSummary()
    {
        Summary = "Returns all the books in the system";
        Description = "Returns all the books in the system";
        Response<GetAllBooksResponse>(200, "All books in the system are returned");
    }
}
