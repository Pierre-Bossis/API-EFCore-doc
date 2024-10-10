namespace API_EFCore.Models.Book
{
    public record BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateOnly ReleaseDate { get; set; }
    }
}
