namespace LibMinimalApi10.Core.Request
{
    public class CreateBooksRequest
    {
        public required string BookName { get; set; }
        public required string Publisher { get; set; }
        public required string Author { get; set; }
        public required decimal Price { get; set; }
        public required int CategoryId { get; set; }
    }
}
