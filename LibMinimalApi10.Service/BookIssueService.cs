using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Core.Request;
using LibMinimalApi10.Persistence;


namespace LibMinimalApi10.Services
{
    public sealed class BookIssueService
    {
        private readonly AppDbContext _dbContext;
        public BookIssueService(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<BookIssueDto> GetBookIssueList()
        {
            IReadOnlyList<BookIssueDto> BookIssue = _dbContext.BookIssue
                  .Select
                  (bi => new BookIssueDto
                  (
                      bi.IssueId,
                      bi.MemberId,
                      bi.BookId,
                      bi.IssueDate,
                      bi.ReturnDate,
                      bi.RenewDate
                  ))
                  .ToList();
            return BookIssue;
        }
        public BookIssueDto? CreateBookIssueRequest(CreateBookIssueRequest request)
        {
            try
            {
                var bookIssue = new Persistence.Data.BookIssue
                {
                    MemberId = request.MemberId,
                    BookId = request.BookId,
                    IssueDate = request.IssueDate,
                    ReturnDate = request.ReturnDate,
                    RenewDate = request.RenewDate
                };
                _dbContext.BookIssue.Add(bookIssue);
                _dbContext.SaveChanges();
                return new BookIssueDto(bookIssue.IssueId, bookIssue.MemberId, bookIssue.BookId, bookIssue.IssueDate, bookIssue.ReturnDate, bookIssue.RenewDate);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while creating the book issue: {ex.Message}");
                return null; // Return null or handle it as per your application's requirements
            }
        }
    }
}

