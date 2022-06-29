namespace MinimalApiBlog.Api.Features.Authors.Models
{
    public record AuthorGetDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
        public string? Bio { get; init; }
        public DateTime BirthDate { get; init; }
    }
}
