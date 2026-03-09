using System.ComponentModel.DataAnnotations;

namespace LibMinimalApi10.Persistence.Data
{
    public sealed class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Name { get; set; }

    }
}
