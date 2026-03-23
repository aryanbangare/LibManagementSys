using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Core.Request;
using LibMinimalApi10.Persistence;
using LibMinimalApi10.Persistence.Data;

namespace LibMinimalApi10.Services
{
    public sealed class BooksService
    {
        private readonly AppDbContext _dbContext;
        public BooksService(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<BooksDto> GetBooksList()
        {
            IReadOnlyList<BooksDto> books = _dbContext.Books.Select(b => new BooksDto(b.BookId, b.BookName, b.Publisher, b.Author, b.Price, b.CategoryId)).ToList();
            return books;
        }
        public BooksDto? CreateBooksRequest(CreateBooksRequest request)
        {
            try
            {
                var book = new Books
                {
                    BookName = request.BookName,
                    Publisher = request.Publisher,
                    Author = request.Author,
                    Price = request.Price,
                    CategoryId = request.CategoryId
                };
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
                return new BooksDto(book.BookId, book.BookName, book.Publisher, book.Author, book.Price, book.CategoryId);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while creating the category: {ex.Message}");
                return null; // Return null or handle it as per your application's requirements
            }
        }

    }
}
