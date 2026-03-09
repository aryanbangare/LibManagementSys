using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibMinimalApi10.Web.Endpoints
{
    public static class BookIssueEndpoints
    {
        public static IEndpointRouteBuilder MapIssuedGroup(this IEndpointRouteBuilder endpoints)
        {

            return endpoints
                .MapGroup("issued");
        }
        public static IEndpointRouteBuilder MapIssueEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            IEndpointRouteBuilder issueGroup = BookIssueEndpoints.MapIssuedGroup(endpoints);

            issueGroup.MapGet("", GetBooks);

            return endpoints;
        }
        public static Ok<IEnumerable<BookIssueDto>> GetBooks(BookIssueService bookIssueService)
        {
            IEnumerable<BookIssueDto> bookIssue = bookIssueService.GetBookIssueList();
            return TypedResults.Ok(bookIssue);
        }
    }
}
