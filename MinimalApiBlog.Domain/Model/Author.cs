namespace MinimalApiBlog.Domain.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FullName => FirstName + " " + LastName;
        public DateTime BirthDate { get; set; }
        public string? Bio { get; set; }
    }
}
