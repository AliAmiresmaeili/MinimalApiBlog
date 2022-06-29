namespace MinimalApiBlog.Api.Features.Authors.Models
{
    public record AuthorDto(string FirstName, string LastName, DateTime BirthDate, string? Bio);
}
