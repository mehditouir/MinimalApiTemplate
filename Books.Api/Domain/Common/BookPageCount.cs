using ValueOf;

namespace Books.Api.Domain.Common
{
    public class BookPageCount : ValueOf<int, BookPageCount>
    {
        protected override void Validate()
        {
            if (Value < 1)
            {
                throw new ArgumentException($"{nameof(BookPageCount)} cannot be empty", nameof(BookPageCount));
            }
        }
    }
}