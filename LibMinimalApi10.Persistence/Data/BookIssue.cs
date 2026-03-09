using System.ComponentModel.DataAnnotations;

namespace LibMinimalApi10.Persistence.Data
{
    public sealed class BookIssue
    {
        [Key]
        public int IssueId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }

        public DateOnly IssueDate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public DateOnly RenewDate { get; set; }

    }
}
