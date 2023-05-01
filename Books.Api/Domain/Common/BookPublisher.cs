using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace Books.Api.Domain.Common
{
    public class BookPublisher : ValueOf<string, BookPublisher>
    {
        private static readonly Regex BookPublisherRegex =
            new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected override void Validate()
        {
            if (!BookPublisherRegex.IsMatch(Value))
            {
                var message = $"{Value} is not valid";
                throw new ValidationException(message, new[]
                {
                new ValidationFailure(nameof(BookPublisher), message)
            });
            }
        }
    }
}