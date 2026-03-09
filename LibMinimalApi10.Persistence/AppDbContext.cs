using Microsoft.EntityFrameworkCore;

namespace LibMinimalApi10.Persistence
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Data.Books> Books { get; set; }
        public DbSet<Data.Category> Category { get; set; }
        public DbSet<Data.Members> Members { get; set; }
        public DbSet<Data.BookIssue> BookIssue { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var t = typeof(AppDbContext);
            modelBuilder.ApplyConfigurationsFromAssembly(t.Assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
