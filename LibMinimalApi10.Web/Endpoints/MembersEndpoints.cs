using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Core.Request;
using LibMinimalApi10.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibMinimalApi10.Web.Endpoints
{
    public static class MembersEndpoints
    {
        public static IEndpointRouteBuilder MapMemberGroup(this IEndpointRouteBuilder endpoints)
        {
            return endpoints
                .MapGroup("members");
        }
        public static IEndpointRouteBuilder MapMemberEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);
            IEndpointRouteBuilder memberGroup = MembersEndpoints.MapMemberGroup(endpoints);
            memberGroup.MapGet("", GetMembers);
            memberGroup.MapPost("", CreateMemberRequest);
            return endpoints;
        }
        public static Ok<IEnumerable<MembersDto>> GetMembers(MemberService membersService)
        {
            IEnumerable<MembersDto> members = membersService.GetMembersList();
            return TypedResults.Ok(members);
        }
        private static IResult CreateMemberRequest(MemberService membersService, CreateMemberRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.MemberName))
                return TypedResults.BadRequest("MemberName is required.");
            if (string.IsNullOrWhiteSpace(request.MemberType))
                return TypedResults.BadRequest("MemberType is required.");
            var result = membersService.CreateMemberRequest(request);
            return result is not null
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest("Failed to create member.");
        }
    }
}