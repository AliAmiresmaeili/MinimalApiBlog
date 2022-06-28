using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Domain.Model;

namespace MinimalApiBlog.Dal
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Article> Articles { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
