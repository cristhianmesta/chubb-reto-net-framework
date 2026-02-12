using Dapper.Contrib.Extensions;

namespace ChubbReto.Domain.Entities
{
    [Table("Genres")]
    public sealed class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
