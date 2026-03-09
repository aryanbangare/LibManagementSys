using System.ComponentModel.DataAnnotations;

namespace LibMinimalApi10.Persistence.Data
{
    public sealed class Books
    {
        [Key]
        public int BookId { get; set; }
        public required string BookName { get; set; }
        public required string Publisher { get; set; }
        public required string Author { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }


    }
}
