namespace MinimalApiBlog.Domain.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Subtitle { get; set; }
        public string Body { get; set; } = default!;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = default!;
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfShares { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
