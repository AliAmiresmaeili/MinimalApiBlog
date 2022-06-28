namespace MinimalApiBlog.Domain.Model
{
    public class Category
    {
        public Category()
        {
            Articles = new List<Article>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<Article> Articles { get; set; }
    }
}
