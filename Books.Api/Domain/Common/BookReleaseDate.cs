using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace Books.Api.Domain.Common
{
    public class BookReleaseDate : ValueOf<DateOnly, BookReleaseDate>
    {
        protected override void Validate()
        {
            if (Value > DateOnly.FromDateTime(DateTime.Now))
            {
                const string message = $"{nameof(BookReleaseDate)} cannot be in the future";
                throw new ValidationException(message, new[]
                {
                new ValidationFailure(nameof(BookReleaseDate), message)
            });
            }
        }
    }
}