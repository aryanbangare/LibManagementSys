using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Core.Request;
using LibMinimalApi10.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibMinimalApi10.Web.Endpoints
{
    public static class BookEndpoint
    {
        public static IEndpointRouteBuilder MapBookGroup(this IEndpointRouteBuilder endpoints)
        {

            return endpoints
                .MapGroup("books");
        }
        public static IEndpointRouteBuilder MapBookEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            IEndpointRouteBuilder bookGroup = BookEndpoint.MapBookGroup(endpoints);

            bookGroup.MapGet("", GetBooks);
            bookGroup.MapPost("", CreateBooksRequest);

            return endpoints;

        }

        private static Ok<IEnumerable<BooksDto>> GetBooks(BooksService bookService)
        {
            IEnumerable<BooksDto> books = bookService.GetBooksList();
            return TypedResults.Ok(books);
        }
        private static IResult CreateBooksRequest(BooksService booksService,CreateBooksRequest request)
        {
           var result = booksService.CreateBooksRequest(request);
            return result is not null
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest("Failed to create book.");
        }
    }
}

