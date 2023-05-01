using Books.Api.Contracts.Responses;
using Books.Api.Endpoints;
using FastEndpoints;

namespace Books.Api.Summaries;

public class CreateBookSummary : Summary<CreateBookEndpoint>
{
    public CreateBookSummary()
    {
        Summary = "Creates a new book in the system";
        Description = "Creates a new book in the system";
        Response<BookResponse>(201, "Book was successfully created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}
