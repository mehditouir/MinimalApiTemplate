using Books.Api.Contracts.Requests;
using Books.Api.Contracts.Responses;
using Books.Api.Mapping;
using Books.Api.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Books.Api.Endpoints;

[HttpPut("books/{id:guid}"), AllowAnonymous]
public class UpdateBookEndpoint : Endpoint<UpdateBookRequest, BookResponse>
{
    private readonly IBookService _bookService;

    public UpdateBookEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override async Task HandleAsync(UpdateBookRequest req, CancellationToken ct)
    {
        var existingBook = await _bookService.GetAsync(req.Id);

        if (existingBook is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var book = req.ToBook();
        await _bookService.UpdateAsync(book);

        var bookResponse = book.ToBookResponse();
        await SendOkAsync(bookResponse, ct);
    }
}
