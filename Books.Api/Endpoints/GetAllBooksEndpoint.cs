using Books.Api.Contracts.Responses;
using Books.Api.Mapping;
using Books.Api.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Books.Api.Endpoints;

[HttpGet("books"), AllowAnonymous]
public class GetAllBooksEndpoint : EndpointWithoutRequest<GetAllBooksResponse>
{
    private readonly IBookService _bookService;

    public GetAllBooksEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var books = await _bookService.GetAllAsync();
        var booksResponse = books.ToBooksResponse();
        await SendOkAsync(booksResponse, ct);
    }
}
