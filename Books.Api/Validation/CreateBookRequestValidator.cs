using Books.Api.Contracts.Requests;
using FluentValidation;

namespace Books.Api.Validation;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Editor).NotEmpty();
        RuleFor(x => x.Publisher).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Pages).NotEmpty();
        RuleFor(x => x.ReleaseDate).NotEmpty();
    }
}
