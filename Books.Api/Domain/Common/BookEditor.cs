using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using ValueOf;

namespace Books.Api.Domain.Common
{
    public class BookEditor : ValueOf<string, BookEditor>
    {
        private static readonly Regex BookEditorRegex =
            new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        protected override void Validate()
        {
            if (!BookEditorRegex.IsMatch(Value))
            {
                var message = $"{Value} is not valid";
                throw new ValidationException(message, new[]
                {
                new ValidationFailure(nameof(BookEditor), message)
            });
            }
        }
    }
}