using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Persistence;

namespace LibMinimalApi10.Services
{
    public sealed class MemberService
    {
        private readonly AppDbContext _dbContext;
        public MemberService(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<MembersDto> GetMembersList()
        {
            IReadOnlyList<MembersDto> Members = _dbContext.Members.Select(m => new MembersDto(m.MemberId, m.MemberName, m.MemberType)).ToList();
            return Members;
        }
    }
}
