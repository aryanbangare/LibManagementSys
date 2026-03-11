using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Core.Request;
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
            issueGroup.MapPost("", CreateBookIssueRequest);
            issueGroup.MapPatch("/{issueId:int}", PatchBookIssueRequest);
            return endpoints;
        }
        public static Ok<IEnumerable<BookIssueDto>> GetBooks(BookIssueService bookIssueService)
        {
            IEnumerable<BookIssueDto> bookIssue = bookIssueService.GetBookIssueList();
            return TypedResults.Ok(bookIssue);
        }
        private static IResult CreateBookIssueRequest(BookIssueService bookIssueService, CreateBookIssueRequest request)
        {
            var result = bookIssueService.CreateBookIssueRequest(request);
            return result is not null
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest("Failed to create book issue.");
        }
        private static IResult PatchBookIssueRequest(BookIssueService bookIssueService, int issueId, PatchBookIssueRequest request)
        {
            var result = bookIssueService.PatchBookIssueRequest(issueId, request);
            return result is not null
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest("Failed to update book issue.");
        }
    }
}
