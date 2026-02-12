using ChubbReto.Domain.Entities;
using ChubbReto.Domain.Repositories;
using ChubbReto.Infraestructure.Database;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BookRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                string sql = @" SELECT 
                                    b.BookId, b.Title, b.Year, b.NumberOfPages, b.AuthorId, b.GenreId,
                                    a.AuthorId, a.FullName,
                                    g.GenreId, g.Name
                                FROM Books b
                                INNER JOIN Authors a ON b.AuthorId = a.AuthorId
                                LEFT JOIN Genres g ON b.GenreId = g.GenreId";

                var books = await connection.QueryAsync<Book, Author, Genre, Book>(
                    sql,
                    (book, author, genre) =>
                    {
                        book.Author = author;
                        book.Genre = genre;
                        return book;
                    },
                    splitOn: "AuthorId,GenreId"
                );

                return books;
            }
        }
        public async Task<int> Add(Book book)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.InsertAsync(book);
            }
        }

        public async Task<int> CountByAuthor(int authorId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT COUNT(*) FROM Books WHERE AuthorId = @AuthorId";
                return await connection.ExecuteScalarAsync<int>(sql, new { AuthorId = authorId });
            }
        }

    }
}
