using LibMinimalApi10.Core.Dtos;
using LibMinimalApi10.Core.Request;
using LibMinimalApi10.Persistence;
using LibMinimalApi10.Persistence.Data;

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

        public CategoryDto? CreateCategoryRequest(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category
                {
                    Name = request.Name
                };
                _dbContext.Category.Add(category);
                _dbContext.SaveChanges();
                return new CategoryDto(category.CategoryId, category.Name);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred while creating the category: {ex.Message}");
                return null;
            }
        }

        public void DeleteCategory(int id)
        {
            Category? category = _dbContext.Category.Find(id);
            if (category is null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }

            _dbContext.Category.Remove(category);
            _dbContext.SaveChanges();

        }
    }
}
