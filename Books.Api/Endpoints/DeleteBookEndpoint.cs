using Books.Api.Contracts.Requests;
using Books.Api.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Books.Api.Endpoints;

[HttpDelete("books/{id:guid}"), AllowAnonymous]
public class DeleteBookEndpoint : Endpoint<DeleteBookRequest>
{
    private readonly IBookService _bookService;

    public DeleteBookEndpoint(IBookService bookService)
    {
        _bookService = bookService;
    }

    public override async Task HandleAsync(DeleteBookRequest req, CancellationToken ct)
    {
        var deleted = await _bookService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
