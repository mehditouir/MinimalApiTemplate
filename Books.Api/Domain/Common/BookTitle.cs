using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace Books.Api.Domain.Common
{
    public class BookTitle : ValueOf<string, BookTitle>
    {
        private static readonly Regex BookTitleRegex =
            new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected override void Validate()
        {
            if (!BookTitleRegex.IsMatch(Value))
            {
                var message = $"{Value} is not valid";
                throw new ValidationException(message, new[]
                {
                new ValidationFailure(nameof(BookTitle), message)
            });
            }
        }
    }
}