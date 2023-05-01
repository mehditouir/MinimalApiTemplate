using Books.Api.Contracts.Requests;
using Books.Api.Contracts.Responses;
using Books.Api.Mapping;
using Books.Api.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Books.Api.Endpoints;

[HttpGet("books/{id:guid}"), AllowAnonymous]
public class GetBookEndpoint : Endpoint<GetBookRequest, BookResponse>
{
    private readonly IBookService _bookService;

    public GetBookEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override async Task HandleAsync(GetBookRequest req, CancellationToken ct)
    {
        var book = await _bookService.GetAsync(req.Id);

        if (book is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var bookResponse = book.ToBookResponse();
        await SendOkAsync(bookResponse, ct);
    }
}
