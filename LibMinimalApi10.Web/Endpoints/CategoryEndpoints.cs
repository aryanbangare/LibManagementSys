using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibMinimalApi10.Web.Endpoints
{
    public static class CategoryEndpoints
    {
        public static IEndpointRouteBuilder MapCategoryGroup(this IEndpointRouteBuilder endpoints)
        {
            return endpoints
                .MapGroup("category");
        }
        public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            IEndpointRouteBuilder categoryGroup = CategoryEndpoints.MapCategoryGroup(endpoints);

            categoryGroup.MapGet("/", GetAllCategory);

            return endpoints;
        }
        private static Ok<IEnumerable<CategoryDto>> GetAllCategory(CategoryService categoryService)
        {
            IEnumerable<CategoryDto> category = categoryService.GetCategoryList();
            return TypedResults.Ok(category);
        }
    }
}       