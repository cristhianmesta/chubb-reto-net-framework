using Dapper.Contrib.Extensions;

namespace ChubbReto.Domain.Entities
{
    [Table("Books")]
    public sealed class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int? GenreId { get; set; }
        public int? NumberOfPages { get; set; }
        public int AuthorId { get; set; }

        [Write(false)]
        public Author Author { get; set; }
        [Write(false)]
        public Genre Genre { get; set; }
    }
}
