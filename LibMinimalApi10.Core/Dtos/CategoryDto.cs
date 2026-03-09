namespace LibMinimalApi10.Core.Dtos
{
    public sealed class CategoryDto(int categoryId, string? name)
    {
        public int CategoryId { get; } = categoryId;

        public string? Name { get; } = name;

    }
}
