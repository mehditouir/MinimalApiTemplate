using Books.Api.Contracts.Responses;
using Books.Api.Endpoints;
using FastEndpoints;

namespace Books.Api.Summaries;

public class UpdateBookSummary : Summary<UpdateBookEndpoint>
{
    public UpdateBookSummary()
    {
        Summary = "Updates an existing book in the system";
        Description = "Updates an existing book in the system";
        Response<BookResponse>(201, "Book was successfully updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}
