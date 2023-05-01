using Books.Api.Contracts.Requests;
using FluentValidation;

namespace Books.Api.Validation;

public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookRequestValidator()
    {
        RuleFor(x => x.Editor).NotEmpty();
        RuleFor(x => x.Publisher).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Pages).NotEmpty();
        RuleFor(x => x.ReleaseDate).NotEmpty();
    }
}
