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
                    IssueDate = DateOnly.FromDateTime(DateTime.Today),
                    ReturnDate = DateOnly.FromDateTime(DateTime.Today).AddDays(30)
                };
                _dbContext.BookIssue.Add(bookIssue);
                _dbContext.SaveChanges();
                return new BookIssueDto(bookIssue.IssueId, bookIssue.MemberId, bookIssue.BookId, bookIssue.IssueDate, bookIssue.ReturnDate, bookIssue.RenewDate);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while creating the book issue: {ex.Message}");
            }
            return null; // Return null or handle it as per your application's requirements
        }
        public BookIssueDto? PatchBookIssueRequest(int issueId, PatchBookIssueRequest request)
        {
            try
            {
                var bookIssue = _dbContext.BookIssue.FirstOrDefault(bi => bi.IssueId == issueId);
                if (bookIssue == null)
                {
                    return null; // Book issue not found
                }
                if (request.RenewDate.HasValue)
                {
                    bookIssue.RenewDate = request.RenewDate.Value;
                }
                _dbContext.SaveChanges();
                return new BookIssueDto(bookIssue.IssueId, bookIssue.MemberId, bookIssue.BookId, bookIssue.IssueDate, bookIssue.ReturnDate, bookIssue.RenewDate);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while updating the book issue: {ex.Message}");
                return null; // Return null or handle it as per your application's requirements
            }
        }
    }
}

