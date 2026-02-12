using ChubbReto.Domain.Entities;
using ChubbReto.Domain.Repositories;
using ChubbReto.Infraestructure.Database;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChubbReto.Infraestructure.Repositories
{
    public class GenreRepositry : IGenreRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public GenreRepositry(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<IEnumerable<Genre>> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return await connection.GetAllAsync<Genre>();
            }
        }
    }
}
