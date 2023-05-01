using ValueOf;

namespace Books.Api.Domain.Common
{
    public class BookId : ValueOf<Guid, BookId>
    {
        protected override void Validate()
        {
            if (Value == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(BookId)} cannot be empty", nameof(BookId));
            }
        }
    }
}