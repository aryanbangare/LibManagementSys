using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Core.Request;
using LibMinimalApi10.Persistence;
using LibMinimalApi10.Persistence.Data;

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
        public MembersDto? CreateMemberRequest(CreateMemberRequest request)
        {
            try
            {
                var member = new Members
                {
                    MemberName = request.MemberName,
                    MemberType = request.MemberType
                };
                _dbContext.Members.Add(member);
                _dbContext.SaveChanges();
                return new MembersDto(member.MemberId, member.MemberName, member.MemberType);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"An error occurred while creating the member: {ex.Message}");
                return null; // Return null or handle it as per your application's requirements
            }
        }

    }
}
