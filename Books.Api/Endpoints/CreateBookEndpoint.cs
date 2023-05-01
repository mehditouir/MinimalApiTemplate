using Books.Api.Contracts.Requests;
using Books.Api.Contracts.Responses;
using Books.Api.Mapping;
using Books.Api.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Books.Api.Endpoints;

[HttpPost("books"), AllowAnonymous]
public class CreateBookEndpoint : Endpoint<CreateBookRequest, BookResponse>
{
    private readonly IBookService _bookService;

    public CreateBookEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
    {
        var book = req.ToBook();

        await _bookService.CreateAsync(book);

        var bookResponse = book.ToBookResponse();
        await SendCreatedAtAsync<GetBookEndpoint>(
            new { Id = book.Id.Value }, bookResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
