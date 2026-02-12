namespace ChubbReto.Application.Books
{
    public class ListBookFullDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int? NumberOfPages { get; set; }
        public string Author { get; set; }
    }
}
