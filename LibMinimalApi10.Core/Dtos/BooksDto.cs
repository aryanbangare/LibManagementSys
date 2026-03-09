namespace LibMinimalApi10.Core.Dtos
{
    public sealed class BooksDto(int bookId, string? bookName, string? publisher, string? author, decimal price, int? categoryId)
    {
        public int BookId { get; } = bookId;
        public string? BookName { get; } = bookName;
        public string? Publisher { get; } = publisher;
        public string? Author { get; } = author;
        public decimal Price { get; } = price;
        public int? CategoryId { get; } = categoryId;

    }
}
