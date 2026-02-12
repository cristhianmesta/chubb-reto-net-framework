using ChubbReto.Domain.Entities;
using ChubbReto.Domain.Repositories;
using ChubbReto.Infraestructure.Database;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Infraestructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AuthorRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.GetAllAsync<Author>();
            }
        }

        public async Task<Author> Get(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.GetAsync<Author>(id);
            }
        }

        public async Task<int> Add(Author author)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.InsertAsync(author);
            }
        }

        public async Task<bool> Exists(string fullName)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "SELECT COUNT(1) FROM Authors WHERE FullName = @FullName";
                var count = await connection.ExecuteScalarAsync<int>(sql, new { FullName = fullName });

                return count > 0;
            }
        }
    }
}
