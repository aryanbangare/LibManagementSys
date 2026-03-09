using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Persistence;

namespace LibMinimalApi10.Services
{
    public sealed class CategoryService
    {
        private readonly AppDbContext _dbContext;
        public CategoryService(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<CategoryDto> GetCategoryList()
        {
            IReadOnlyList<CategoryDto> Category = _dbContext.Category.Select(c => new CategoryDto(c.CategoryId, c.Name)).ToList();
            return Category;
        }
    }
}
