using LibMinimalApi10.Core.Dtos;
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
    }
}

