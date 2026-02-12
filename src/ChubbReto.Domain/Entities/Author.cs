using Dapper.Contrib.Extensions;
using System;

namespace ChubbReto.Domain.Entities
{
    [Table("Authors")]
    public sealed class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CityOfOrigin { get; set; }
        public string Email { get; set; }
    }
}
