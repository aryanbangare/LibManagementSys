

namespace LibMinimalApi10.Core.Dtos
{
    public sealed class BookIssueDto(int IssueId, int MemberId, int BookId, DateOnly IssueDate, DateOnly ReturnDate, DateOnly RenewDate)
    {
        public int IssueId { get; } = IssueId;
        public int MemberId { get; } = MemberId;
        public int BookId { get; } = BookId;
        public DateOnly IssueDate { get; } = IssueDate;
        public DateOnly ReturnDate { get; } = ReturnDate;
        public DateOnly RenewDate { get; } = RenewDate;
    }
}
