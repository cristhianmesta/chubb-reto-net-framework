namespace ChubbReto.Application.Books
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int? GenreId { get; set; }
        public int? NumberOfPages { get; set; }
        public int AuthorId { get; set; }
    }
}
