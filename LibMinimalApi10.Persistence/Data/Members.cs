using System.ComponentModel.DataAnnotations;

namespace LibMinimalApi10.Persistence.Data
{
    public sealed class Members
    {
        [Key]
        public int MemberId { get; set; }
        public string? MemberName { get; set; }
        public string? MemberType { get; set; }

    }
}
