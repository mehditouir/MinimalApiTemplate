using Books.Api.Endpoints;
using FastEndpoints;

namespace Books.Api.Summaries;

public class DeleteBookSummary : Summary<DeleteBookEndpoint>
{
    public DeleteBookSummary()
    {
        Summary = "Deleted a book the system";
        Description = "Deleted a book the system";
        Response(204, "The book was deleted successfully");
        Response(404, "The book was not found in the system");
    }
}
