using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Persistence;

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
    }
}
